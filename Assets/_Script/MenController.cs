using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Head collision");
        GameEvents.OnGameEnd?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Head collision");
        GameEvents.OnGameEnd?.Invoke();
    }
}
