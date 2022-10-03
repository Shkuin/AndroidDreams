using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConstrain : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCarObj;

    public GameObject carSpawner;
    private CarSpawner _carSpawnerScript;
    private List<float> _coordinateList;

    void Start()
    {
        float mainCarWidth = Math.Abs(_mainCarObj.transform.localScale.x);
        float mainCameraHeight = Camera.main.orthographicSize;
        float mainCameraWidth = mainCameraHeight * Screen.width / Screen.height;
        GetComponent<BoxCollider2D>().size = new Vector2(1, mainCameraHeight * 2);
        GetComponent<BoxCollider2D>().offset = new Vector2(mainCameraWidth - mainCarWidth, 0);

        _carSpawnerScript = carSpawner.GetComponent<CarSpawner>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GeneratedCars")
        {
            Debug.Log("Delete this file pls");
            //_coordinateList = _carSpawnerScript.GetYCoordinateList();
            //_coordinateList.Remove(other.transform.position.y);
            //_carSpawnerScript.SetYCoordinateList(_coordinateList);
            //_carSpawnerScript._yCoordinateList.Remove(other.transform.position.y);
            //yCoordinateList.Remove(other.transform.position.y);
            //PrintList(_coordinateList);
        }
    }

    private void PrintList(List<float> myList)
    {
        for (int i = 0; i < myList.Count; i++)
        {
            Debug.Log(myList[i]);
        }
    }
}
