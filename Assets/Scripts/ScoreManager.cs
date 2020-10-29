using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float score = 0;

    [SerializeField]
    private Text scoreDisplay;


    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
