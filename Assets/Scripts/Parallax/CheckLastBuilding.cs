using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLastBuilding : MonoBehaviour
{
    public static bool _bCityGenCond = false;

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MidCity")
        {
            _bCityGenCond = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "MidCity")
        {
            _bCityGenCond = false;
        }
    }
}
