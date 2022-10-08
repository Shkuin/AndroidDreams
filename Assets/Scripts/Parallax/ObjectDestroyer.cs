using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{ 
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MidCity" || other.gameObject.tag == "GeneratedCarsLeft" || other.gameObject.tag == "GeneratedCarsRight")
        {
            Destroy(other.gameObject);
        }
    }
}
