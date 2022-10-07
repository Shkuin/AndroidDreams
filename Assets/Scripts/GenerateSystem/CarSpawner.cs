using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    private List<GameObject> _genCars;
    private float _timeRangeStart;
    private float _timeRangeStop;
    private Vector3 _genPosition;

    public CarSpawner(List<GameObject> genCars, float timeRangeStart, float timeRangeStop, Vector3 genPosition)
    {
        _genCars = genCars;
        _timeRangeStart = timeRangeStart;
        _timeRangeStop = timeRangeStop;
        _genPosition = genPosition;
    }

    public void Spawn()
    {
        int curCarIndex = Random.Range(0, _genCars.Count - 1);
        Instantiate(_genCars[curCarIndex], _genPosition, Quaternion.identity);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        float waitingTime = Random.Range(_timeRangeStart, _timeRangeStop);
        yield return new WaitForSeconds(waitingTime);
    }
}
