using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMoving : MonoBehaviour
{
    public float speed = -3f;
    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        float boostCoeff = 10f + moveDirection.x * 4f;
        _rigidbody.AddForce(new Vector2(speed * boostCoeff, 0f), ForceMode2D.Force);
    }
}