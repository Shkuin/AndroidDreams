using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGeneration : MonoBehaviour
{
    [SerializeField] private List<GameObject> _genCars;
    public float _timeRangeStart;
    public float _timeRangeStop;
    public int _roadIndex;

    void Start()
    {
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        float yPosition;
        if (_roadIndex == 0)
            yPosition = cameraHalfHeight * 0.75f;
        else if (_roadIndex == 1)
            yPosition = cameraHalfHeight * 0.25f;
        else if (_roadIndex == 2)
            yPosition = -cameraHalfHeight * 0.75f;
        else
            yPosition = -cameraHalfHeight * 0.25f;

        GetComponent<BoxCollider2D>().offset = new Vector2(cameraHalfWidth + 5, yPosition);
        //Spawn();
        StartCoroutine(Wait());
    }

    public void Spawn()
    {
        StartCoroutine(Wait());
        //Spawn();
    }

    private IEnumerator Wait()
    {
        float waitingTime = Random.Range(_timeRangeStart, _timeRangeStop);
        yield return new WaitForSeconds(waitingTime);
        int curCarIndex = Random.Range(0, _genCars.Count - 1);
        GameObject gameObject =  Instantiate(_genCars[curCarIndex], new Vector3(GetComponent<BoxCollider2D>().offset.x, GetComponent<BoxCollider2D>().offset.y, 0f), Quaternion.identity);
        gameObject.SetActive(true);
        StartCoroutine(Wait());
    }
}
