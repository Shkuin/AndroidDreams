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
    [SerializeField] private TextMeshProUGUI _scoreField;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _score++;
        _scoreField.text = _score.ToString();

    }
}
