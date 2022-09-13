using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = -2f;
    public float lowerXValue = -31.78f;
    public float upperXValue = 84.38f;
    void Update()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        float boostCoeff = 1 + moveDirection.x * 0.1f;

        transform.Translate(speed * Time.deltaTime * boostCoeff, 0f, 0f);
        if (transform.position.x <= lowerXValue)
        {
            transform.Translate(upperXValue, 0f, 0f);
        }
    }
}
