using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Head collision OnCollisionEnter2D");
        GameEvents.OnGameEnd?.Invoke();
    }
}
