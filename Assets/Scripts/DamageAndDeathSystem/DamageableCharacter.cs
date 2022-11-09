using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public bool invincible = false;

    [SerializeField]
    private float _health = 100f;

    public float invinciblityTime = 0.25f;
    public float explosionTime;
    public float explosionSpeedCoef;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
                if (_animator != null)
                {
                    _animator.Play("GenCar_Explosion", 0, 0f);
                    float time = _animator.GetCurrentAnimatorStateInfo(0).length;
                    Invoke("OnObjectDestroyed", time + explosionTime);
                    _rigidbody.simulated = false;
                    transform.Translate(explosionSpeedCoef, 0, 0);
                }
                else
                {
                    Debug.LogWarning("This object doesn't have animator");
                }
                //OnObjectDestroyed();
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
