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
    //private List<float> _yCoordinateList = new List<float>();

    void Start()
    {
        _mainCarHeight = Math.Abs(_mainCarObj.transform.localScale.y);
        _generatedCarHeight = Math.Abs(_rightMoveCarsObj.transform.localScale.y);
        _mainCameraHeight = Camera.main.orthographicSize;
        _mainCameraWidth = _mainCameraHeight * Screen.width / Screen.height;
        // ------
        float y = Random.Range(_generatedCarHeight / 5, _mainCameraHeight - _generatedCarHeight / 2);
        _spawnGameObject = Instantiate(_leftMoveCarsObj, new Vector2(_mainCameraWidth, y), Quaternion.identity);
        //_yCoordinateList.Add(y);
    }

    private float SetYCooridinateWithConstr()
    {
        int[] signArray = {-1, 1, 1};
        float randY = 0;
        while (CheckConstrainForSpawnPoint(randY))
        {
            randY = Random.Range(_generatedCarHeight / 5, _mainCameraHeight - _generatedCarHeight / 2) * signArray[Random.Range(0,3)];
        }
        //_yCoordinateList.Add(randY);
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
        //bool constrain = false;
        //for (int i = 0; i < _yCoordinateList.Count; i++)
        //{
        //    if (!constrain)
        //    {
        //        constrain = (coordinate >= _yCoordinateList[i] - _mainCarHeight * 2) &
        //                    (coordinate <= _yCoordinateList[i] + _mainCarHeight * 2);
        //    }
        //}
        return (coordinate >= -_generatedCarHeight / 2 & coordinate <= _generatedCarHeight / 2) |
               (coordinate <= -_mainCameraHeight + _generatedCarHeight / 2 |
                coordinate >= _mainCameraHeight - _generatedCarHeight / 2) |
               (coordinate <= _spawnGameObject.transform.position.y + _mainCarHeight &
                coordinate >= _spawnGameObject.transform.position.y - _mainCarHeight);
        //constrain;
    }

    //public List<float> GetYCoordinateList()
    //{
    //    return _yCoordinateList;
    //}

    //public void SetYCoordinateList(List<float> coordinateList)
    //{
    //    _yCoordinateList = coordinateList;
    //}
}