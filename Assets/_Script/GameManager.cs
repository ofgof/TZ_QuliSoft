using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ViewController _viewController;
    [SerializeField] private CarController _carController;
    [SerializeField] private LevelCreator _levelCreator;

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        _viewController.Init();
        _carController.Init();
        _levelCreator.Init();

        GameEvents.OnGameEnd += RestartGame;
    }
    private void OnDestroy()
    {
        GameEvents.OnGameEnd -= RestartGame;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
