using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;
    public void Move(float iDelta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= iDelta * parallaxFactor;
        transform.localPosition = newPos;
    }
}