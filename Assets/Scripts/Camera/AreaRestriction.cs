using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AreaRestriction : MonoBehaviour
{
    public GameObject area;
    [SerializeField] private GameObject generatedCar;
    void Start()
    {
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        float generatedCarLength = generatedCar.transform.localScale[0];

        area.transform.GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(1, cameraHeight);
        area.transform.GetChild(0).GetComponent<BoxCollider2D>().offset = new Vector2(-cameraWidth / 2, 0);
        area.transform.GetChild(1).GetComponent<BoxCollider2D>().size = new Vector2(1, cameraHeight);
        area.transform.GetChild(1).GetComponent<BoxCollider2D>().offset = new Vector2(-cameraWidth / 2, 0);
        area.transform.GetChild(2).GetComponent<BoxCollider2D>().size = new Vector2(1, cameraHeight);
        area.transform.GetChild(2).GetComponent<BoxCollider2D>().offset = new Vector2(cameraWidth / 2, 0);
        area.transform.GetChild(3).GetComponent<BoxCollider2D>().size = new Vector2(1, cameraHeight);
        area.transform.GetChild(3).GetComponent<BoxCollider2D>().offset = new Vector2(cameraWidth / 2, 0);
        area.transform.GetChild(4).GetComponent<BoxCollider2D>().size = new Vector2(cameraWidth, 1);
        area.transform.GetChild(4).GetComponent<BoxCollider2D>().offset = new Vector2(0, -(cameraHeight + 1) / 2);
        area.transform.GetChild(5).GetComponent<BoxCollider2D>().size = new Vector2(cameraWidth + generatedCarLength, 1);
        area.transform.GetChild(5).GetComponent<BoxCollider2D>().offset = new Vector2(0, (cameraHeight + 1) / 2);
    }

}

