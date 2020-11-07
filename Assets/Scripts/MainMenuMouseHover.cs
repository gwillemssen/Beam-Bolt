using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseEnter()
    {
        //set material to red when mouse enters box collider
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    void OnMouseExit()
    {
        //set material back to white when mouse leave box collider
        GetComponent<Renderer>().material.color = Color.white;
    }
}
