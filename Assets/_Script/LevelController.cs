using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private Transform _palyerTransform;

    public void Init()
    {
        _levelCreator.CreatChunk();
    }
}
