using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject _leftMoveCarsObj;
    [SerializeField]
    private GameObject _rightMoveCarsObj;
    [SerializeField]
    private GameObject _mainCarObj;
    [SerializeField]
    private float _spawnRate = 2f;

    private GameObject _spawnGameObject;
    private float _mainCameraHeight;
    private float _mainCarHeight;
    private float _generatedCarHeight;
    private float _nextSpawn = 1.0f;
    private float _mainCameraWidth;

    void Start()
    {
        _mainCarHeight = Math.Abs(_mainCarObj.transform.localScale.y);
        _generatedCarHeight = Math.Abs(_rightMoveCarsObj.transform.localScale.y);
        _mainCameraHeight = Camera.main.orthographicSize;
        _mainCameraWidth = _mainCameraHeight * Screen.width / Screen.height;
        // тот косяк
        float y = Random.Range(_generatedCarHeight / 5, _mainCameraHeight - _generatedCarHeight / 2);
        _spawnGameObject = Instantiate(_leftMoveCarsObj, new Vector2(_mainCameraWidth, y), Quaternion.identity);
    }

    private float SetYCooridinateWithConstr()
    {
        // массив что бы случайно спавнились машины с разными направлениями движения, положительных больше, что бы машин с одного и с другого потока на
        // экране было +- одинаково
        int[] signArray = {-1, 1, 1};
        float randY = 0;
        while (CheckConstrainForSpawnPoint(randY))
        {
            randY = Random.Range(_generatedCarHeight / 2, _mainCameraHeight - _generatedCarHeight / 2) * signArray[Random.Range(0,3)];
        }
        return randY;
    }

    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;
            float coordinateY = SetYCooridinateWithConstr();
            Vector2 whereToSpawn = new Vector2(_mainCameraWidth, coordinateY);
            if (coordinateY < 0) _spawnGameObject = Instantiate(_rightMoveCarsObj, whereToSpawn, Quaternion.identity);
            else _spawnGameObject = Instantiate(_leftMoveCarsObj, whereToSpawn, Quaternion.identity);
        }
    }

    private bool CheckConstrainForSpawnPoint(float coordinate)
    {
        return // ограничение что бы машины с разных потоков не спавнились друг в друге
            (coordinate >= -_generatedCarHeight / 2 & coordinate <= _generatedCarHeight / 2) |
            // что бы машинки не спавнились слишком близко друг к другу
               (coordinate <= _spawnGameObject.transform.position.y + _mainCarHeight &
                coordinate >= _spawnGameObject.transform.position.y - _mainCarHeight);
    }
}
