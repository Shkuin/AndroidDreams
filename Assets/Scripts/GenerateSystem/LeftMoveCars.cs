using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMoveCars : MonoBehaviour
{
    public float speed = -6f;

    void Update()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        float boostCoeff = 1 + moveDirection.x * 0.4f;
        transform.Translate(speed * Time.deltaTime * boostCoeff, 0f, 0f);
    } 
}
