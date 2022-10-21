using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is null!");
            return _instance;
        }
    }

    private int _score;
    private int _complexityLimit = 3000;
    [SerializeField] private GameObject _mainCar;
    [SerializeField] private TextMeshProUGUI _scoreField;
    [SerializeField] private List<GameObject> _genCars;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _botCity;
    [SerializeField] private List<GameObject> _midCity;


    private void Awake()
    {
        _instance = this;

        BringValuesToDefault();
    }

    private void BringValuesToDefault()
    {
        _mainCar.GetComponent<CharacterController2D>().runSpeed = 12;
        DefaultTrafficCarsValues();
        DefaultCityValues();
    }

    private void DefaultCityValues()
    {
        _background.GetComponent<ScrollBackground>().speed = -0.8f;
        _botCity.GetComponent<ScrollBackground>().speed = -1.2f;
        foreach (var building in _midCity)
            building.GetComponent<ScrollMidCity>().speed = -1.8f;
    }

    private void DefaultTrafficCarsValues()
    {
        foreach (var car in _genCars)
            car.GetComponent<CarsMoving>().speed = car.name == "LeftMoveCars" ? -17 : -10;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _score++;
        _scoreField.text = _score.ToString();

        if (_score > _complexityLimit)
        {
            _complexityLimit += 3000;

            _mainCar.GetComponent<CharacterController2D>().runSpeed += 1;

            foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("GeneratedCarsRight"))
            {
                fooObj.GetComponent<CarsMoving>().speed -= 1;
            }

            foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("GeneratedCarsLeft"))
            {
                fooObj.GetComponent<CarsMoving>().speed -= 1;
            }

            foreach (var car in _genCars)
                car.GetComponent<CarsMoving>().speed -= 1;

            _background.GetComponent<ScrollBackground>().speed -= 0.1f;
            _botCity.GetComponent<ScrollBackground>().speed -= 0.15f;

            //foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("MidCity"))
            //{
                //fooObj.GetComponent<ScrollMidCity>().speed -= 0.2f;
            //}

            foreach (var building in _midCity)
                building.GetComponent<ScrollMidCity>().speed -= 0.2f;
        }
    }
}
