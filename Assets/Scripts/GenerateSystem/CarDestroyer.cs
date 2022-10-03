using UnityEngine;

public class CarDestroyer : MonoBehaviour
{
    void Start()
    {
        float mainCameraHeight = Camera.main.orthographicSize;
        float mainCameraWidth = mainCameraHeight * Screen.width / Screen.height;
        // задаю положение Box collider
        GetComponent<BoxCollider2D>().size = new Vector2(1f, mainCameraHeight * 2);
        GetComponent<BoxCollider2D>().offset = new Vector2(-mainCameraWidth, 0);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GeneratedCars")
        {
            Destroy(other.gameObject);
        }
    }
}
