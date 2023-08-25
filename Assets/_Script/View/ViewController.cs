using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [SerializeField] private InGameView _gameView;

    public void Init()
    {
        _gameView.Init();
    }
}
