using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static Action<float> OnUpdatePlayerPosition;

    [Header("Car")]
    [SerializeField] private Rigidbody2D _frontTire;
    [SerializeField] private Rigidbody2D _backTire;
    [SerializeField] private float _speed = 100f;

    [SerializeField] private Rigidbody2D _car;
    [SerializeField] private float _rotationSpeed = 100f;

    public void Init()
    {
        GameEvents.OnGas += Gas;
        GameEvents.OnBreake += Breake;

        GameEvents.OnTestDeth += TestDeth;
    }
    private void OnDestroy()
    {
        GameEvents.OnGas -= Gas;
        GameEvents.OnBreake -= Breake;

        GameEvents.OnTestDeth -= TestDeth;
    }
    private void FixedUpdate()
    {
        OnUpdatePlayerPosition?.Invoke(transform.position.x);
    }
    private void Gas()
    {
        AccelirateForward();
        RotateForward();
    }
    private void Breake()
    {
        AccelirateBackward();
        RotateBackward();
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

    private void TestDeth()
    {
        _car.gameObject.transform.position = _car.gameObject.transform.position + Vector3.up * 5f;
        _car.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
