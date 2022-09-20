using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    [SerializeField] private List<GameObject> _midCity;
    private float _genRange;
    void Start()
    {
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        GetComponent<BoxCollider2D>().offset = new Vector2(cameraHalfWidth + 1, -cameraHalfHeight);
        _genRange = _midCity[0].GetComponent<SpriteRenderer>().size.x;
    }

    void Update()
    {
        if (CheckLastBuilding._bCityGenCond)
        {
            int curBuildingIndex = Random.Range(0, 4);
            float curBuildingPositionX = Random.Range(0f, _genRange) / 2f + GetComponent<BoxCollider2D>().offset.x;
            Instantiate(_midCity[curBuildingIndex], new Vector3(curBuildingPositionX, GetComponent<BoxCollider2D>().offset.y, 0f), Quaternion.identity);
            CheckLastBuilding._bCityGenCond = false;
        }
    }
}
