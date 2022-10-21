using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigidbody;

    public bool invincible = false;

    [SerializeField]
    private float _health = 100f;

    public float invinciblityTime = 0.25f;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public float Health
    {
        set
        {
            if (value < _health)
            {
                //play animation of hit
            }

            _health = value;

            if (_health <= 0)
            {
                //play death animation
                OnObjectDestroyed();
            }
        }
        get
        {
            return _health;
        }
    }

    public void Damage(float damage)
    {
        if (!invincible)
        {
            Health -= damage;
        }
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public void Damage(float damage, Vector2 knockback)
    {
        if (!invincible)
        {
            Health -= damage;
            _rigidbody.AddForce(knockback, ForceMode2D.Impulse);
        }
    }
}
