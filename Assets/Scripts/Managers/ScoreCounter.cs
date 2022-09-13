using System.Collections;
using System.Collections.Generic;
using Ink.Parsed;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreField;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = Time.frameCount / 20;
        scoreField.text = currentScore.ToString();
    }
}
