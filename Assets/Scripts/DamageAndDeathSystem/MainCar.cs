using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCar : MonoBehaviour
{
    public float knockbackForce = 20f;
    public float playerInputForceCoef;
    public float speedDamageCoef;

    public float damage = 10f;

    void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        collider.gameObject.SetActive(true);
        IDamageable damageable = collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Vector2 mainCarDirection = InputManager.GetInstance().GetMoveDirection().normalized;
            if (!collision.gameObject.CompareTag("MainCar"))
            {
                Vector2 direction = (collider.transform.position - transform.position).normalized;
                knockbackForce -= mainCarDirection.x == 0 ? 0 : knockbackForce / playerInputForceCoef;
                Vector2 knockback = direction * knockbackForce * collider.GetComponent<Rigidbody2D>().mass;
                damage += mainCarDirection.x * speedDamageCoef;
                damageable.Damage(damage, knockback);
            }
        }
    }
}
