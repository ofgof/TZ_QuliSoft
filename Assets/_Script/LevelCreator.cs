using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class LevelCreator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _groundSpriteShape1;
    [SerializeField] private SpriteShapeController _groundSpriteShape2;

    [SerializeField] private int _levelLength = 100;
    [SerializeField] private float _xPointsDistance = 2f;
    [SerializeField] private float _yPointsDistance = 2f;
    [SerializeField] private float _smoothness = 0.5f;
    [SerializeField] private float _noiseSeed = 0.5f;
    [SerializeField] private float _bottom = 10f;

    private Vector3 _lastPosition;

    private void OnValidate()
    {
        CreatChunk();
    }
    public void Init()
    {
        _lastPosition = transform.position;
        _groundSpriteShape1.spline.Clear();
        _groundSpriteShape2.spline.Clear();
    }
    public void CreatChunk()
    {
        Spline spline = _groundSpriteShape1.spline;
        if(_groundSpriteShape1.spline.GetPointCount() == 0)
        {
            spline = _groundSpriteShape1.spline;
        }
        else if(_groundSpriteShape2.spline.GetPointCount() == 0)
        {
            spline = _groundSpriteShape2.spline;
        }


        for (int i = 0; i < _levelLength; i++)
        {            
            _lastPosition = new Vector3(_lastPosition.x + _xPointsDistance, Mathf.PerlinNoise(0, i * _noiseSeed) * _yPointsDistance);
            spline.InsertPointAt(i, _lastPosition);

            if (0 < i && i < _levelLength - 1)
            {
                spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                var xSmoothness = _xPointsDistance * _smoothness;
                spline.SetLeftTangent(i, Vector3.left * xSmoothness);
                spline.SetRightTangent(i, Vector3.right * xSmoothness);
            }
        }

        spline.InsertPointAt(_levelLength, new Vector3(_lastPosition.x, transform.position.y - _bottom));
        spline.InsertPointAt(_levelLength + 1, new Vector3(transform.position.x, transform.position.y - _bottom));
    }
    public float GetLastPointPosition()
    {
        return _lastPosition.x;
    }
}
