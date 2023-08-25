using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [SerializeField] private CustomButton _gasButton;
    [SerializeField] private CustomButton _breakeButton;
    [SerializeField] private Button _testDethButton;

    private Coroutine _gasCoroutine;
    private Coroutine _breakeCoroutine;
    public void Init()
    {
        _gasButton.onPress.AddListener(() =>
        {
            _gasCoroutine = StartCoroutine(Gas());
        });
        _gasButton.onRelease.AddListener(() =>
        {
            StopCoroutine(_gasCoroutine);
        });
        _breakeButton.onPress.AddListener(() =>
        {
            _breakeCoroutine = StartCoroutine(Breake());
        });
        _breakeButton.onRelease.AddListener(() =>
        {
            StopCoroutine(_breakeCoroutine);
        });

        _testDethButton.onClick.AddListener(() =>
        {
            GameEvents.OnTestDeth?.Invoke();
        });
    }
    private IEnumerator Gas()
    {
        while (true)
        {
            GameEvents.OnGas?.Invoke();
            yield return new WaitForFixedUpdate();
        }
    }
    private IEnumerator Breake()
    {
        while (true)
        {
            GameEvents.OnBreake?.Invoke();
            yield return new WaitForFixedUpdate();
        }
    }
}
