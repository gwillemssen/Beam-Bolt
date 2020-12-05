using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMesh textObject = GameObject.Find("scoreDisplay").GetComponent<TextMesh>();
        textObject.text = ScoreManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
