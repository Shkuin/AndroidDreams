using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCar : MonoBehaviour
{
    public float damage;
    public float knockbackForce;
    public float speedDamageCoef;
    public float playerInputForceCoef;

    private float accidentWaveCoef;
    private float damageWaveCoef;

    void Start()
    {
        accidentWaveCoef = knockbackForce / 4;
        damageWaveCoef = damage / 5;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Vector2 mainCarDirection = InputManager.GetInstance().GetMoveDirection().normalized;
            if (collision.gameObject.CompareTag("MainCar"))
            {
                Vector2 direction = (collider.transform.position - transform.position).normalized;
                knockbackForce -= mainCarDirection.x == 0 ? 0 : knockbackForce / playerInputForceCoef;
                Vector2 knockback = direction * knockbackForce * collider.GetComponent<Rigidbody2D>().mass;
                damage += mainCarDirection.x * speedDamageCoef;
                damageable.Damage(damage, knockback);
            }
            else
            {
                Vector2 direction = (collider.transform.position - transform.position).normalized;
                Vector2 knockback = direction * accidentWaveCoef * collider.GetComponent<Rigidbody2D>().mass;
                damageable.Damage(damageWaveCoef, knockback);
            }
        }
    }
}
