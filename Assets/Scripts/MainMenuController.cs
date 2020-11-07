using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private bool isStart, isExit;


    private void OnMouseUp()
    {
        if (isStart)
        {
            //Load the main game scene (SampleScene) if "Start" is clicked
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Scene Loaded!");
        }
        if (isExit)
        {
            //Exit game if exit is clicked
            Application.Quit();
            Debug.Log("Scene Loaded!");
        }
    }
}
