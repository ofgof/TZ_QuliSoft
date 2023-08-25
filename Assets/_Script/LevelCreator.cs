using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class LevelCreator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController[] _groundSpriteShapeList;

    [SerializeField] private int _levelPoints = 100;
    [SerializeField] private float _xPointsDistance = 2f;
    [SerializeField] private float _yPointsDistance = 2f;
    [SerializeField] private float _smoothness = 0.5f;
    [SerializeField] private float _noiseSeed = 0.5f;
    [SerializeField] private float _bottom = 10f;

    private float _levelLength;

    private Vector3 _lastPosition;
    private int _currentChunk = 0;
    public void Init()
    {
        _levelLength = (_levelPoints - 1) * _xPointsDistance;
        _lastPosition = transform.position;
        _currentChunk = 0;
        _groundSpriteShapeList = transform.GetComponentsInChildren<SpriteShapeController>();
        foreach (var spriteShape in _groundSpriteShapeList)
        {
            spriteShape.spline.Clear();
            CreatChunk();
        }

        CarController.OnUpdatePlayerPosition += IsNewChunkNeeded;
    }
    private void OnDestroy()
    {        
        CarController.OnUpdatePlayerPosition -= IsNewChunkNeeded;
    }
    private void IsNewChunkNeeded(float xPosition)
    {
        int index = _currentChunk % _groundSpriteShapeList.Length;
        if (_groundSpriteShapeList[index].transform.position.x + _levelLength * 1.5f < xPosition)
        {
            CreatChunk();
        }
    }
    private void CreatChunk()
    {
        int index = _currentChunk % _groundSpriteShapeList.Length;
        var ground = _groundSpriteShapeList[index];
        Spline spline = ground.spline;

        GenerateSurface(spline);

        GenerateBottomPoints(spline);

        var position = ground.transform.position;
        position.x = _levelLength * _currentChunk;
        ground.transform.position = position;

        _currentChunk++;
    }
    private void GenerateSurface(Spline spline)
    {
        spline.Clear();

        for (int i = 0; i < _levelPoints; i++)
        {
            if (i == 0)
            {
                _lastPosition = new Vector3(transform.position.x + _xPointsDistance * i, _lastPosition.y);
            }
            else
            {
                _lastPosition = new Vector3(transform.position.x + _xPointsDistance * i, Mathf.PerlinNoise(0, i * _noiseSeed * _noiseSeed) * _yPointsDistance);
            }

            spline.InsertPointAt(i, _lastPosition);

            if (0 < i && i < _levelPoints - 1)
            {
                spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                var xSmoothness = _xPointsDistance * _smoothness;
                spline.SetLeftTangent(i, Vector3.left * xSmoothness);
                spline.SetRightTangent(i, Vector3.right * xSmoothness);
            }
        }
    }
    private void GenerateBottomPoints(Spline spline)
    {
        spline.InsertPointAt(_levelPoints, new Vector3(_lastPosition.x, transform.position.y - _bottom));
        spline.InsertPointAt(_levelPoints + 1, new Vector3(transform.position.x, transform.position.y - _bottom));
    }
}
