using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = -2f;

    void Update()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        float boostCoeff = 1 + moveDirection.x * 0.1f;

        float cameraWidth = 2f * Camera.main.orthographicSize * Camera.main.aspect;
        float backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float lowerXValue = -(backgroundWidth + cameraWidth) / 2;
        float upperXValue = 2 * backgroundWidth;

        transform.Translate(speed * boostCoeff / 100, 0f, 0f);
        if (transform.position.x <= lowerXValue)
        {
            transform.Translate(upperXValue, 0f, 0f);
        }
    }

}
