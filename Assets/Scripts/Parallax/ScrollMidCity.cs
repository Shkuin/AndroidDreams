using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMidCity : MonoBehaviour
{
    private float speed = -2f;
    void Update()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        float boostCoeff = 1 + moveDirection.x * 0.1f;

        transform.Translate(speed * boostCoeff / 100, 0f, 0f);
    }
}
