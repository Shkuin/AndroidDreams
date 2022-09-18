using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public SpriteRenderer background;
    void Awake()
    {
        Camera.main.orthographicSize = background.bounds.size.y / 2; // for universal landscape size in different mobiles
    }
}
