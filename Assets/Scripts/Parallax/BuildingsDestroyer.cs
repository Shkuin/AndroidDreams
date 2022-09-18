using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsDestroyer : MonoBehaviour
{ 
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MidCity")
        {
            Destroy(other.gameObject);
        }
    }
}
