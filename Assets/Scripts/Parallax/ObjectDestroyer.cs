using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{ 
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MidCity" || other.gameObject.tag == "GeneratedCars")
        {
            Destroy(other.gameObject);
        }
    }
}
