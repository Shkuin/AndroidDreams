using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyFromAccident : MonoBehaviour
{
    [SerializeField] private float _speedDamage = 5;
    public float mainCarHP = 100; 

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        if (other.gameObject.tag == "GeneratedCarsLeft")
        {
            Destroy(other.gameObject);
            //play animation
            mainCarHP -= moveDirection[0] == 0 ? 50 : 50 + moveDirection[0] * _speedDamage;
        }

        if (other.gameObject.tag == "GeneratedCarsRight")
        {
            mainCarHP -= moveDirection[0] == 0 ? 30 : 30 + moveDirection[0] * _speedDamage;
        }
    }
    void Update()
    {
        if (mainCarHP <= 0)
        {
            SceneManager.LoadScene("DamageAndDeathSystem");
        }
    }
}
