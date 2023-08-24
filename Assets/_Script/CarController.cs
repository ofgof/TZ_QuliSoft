using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTire;
    [SerializeField] private Rigidbody2D _backTire;
    [SerializeField] private float _speed = 100f;

    [SerializeField] private Rigidbody2D _car;
    [SerializeField] private float _rotationSpeed = 100f;

    private void Start()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            AccelirateForward();
            RotateForward();
        }
        if (Input.GetMouseButton(1))
        {
            AccelirateBackward();
            RotateBackward();
        }
    }
    private void AccelirateForward()
    {
        Accelirate(-1);
    }
    private void AccelirateBackward()
    {
        Accelirate(1);
    }
    private void Accelirate(int dir)
    {
        dir = Math.Sign(dir);
        _frontTire.AddTorque(dir * _speed * Time.fixedDeltaTime);
        _backTire.AddTorque(dir * _speed * Time.fixedDeltaTime);
    }
    private void RotateForward()
    {
        RotateInAir(1);
    }
    private void RotateBackward()
    {
        RotateInAir(-1);
    }
    private void RotateInAir(int dir)
    {
        dir = Math.Sign(dir);
        _car.AddTorque(dir * _speed * Time.fixedDeltaTime);
    }
}
