using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;

    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private float zTopBorder;

    [SerializeField]
    private float zBottomBorder;

    [SerializeField]
    private float xLeftBorder;

    [SerializeField]
    private float xRightBorder;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //assign control to horizontalInput to move player up/down
        verticalInput = Input.GetAxis("Vertical");
        //assign control to the horizontalInput to move player left/right
        horizontalInput = Input.GetAxis("Horizontal");

        //move player up/down
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        //move player left/right
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //check to make sure player stays inbounds
        if (transform.position.z > zTopBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopBorder);
        }

        if (transform.position.z < zBottomBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottomBorder);
        }

        if (transform.position.x < xLeftBorder)
        {
            transform.position = new Vector3(xLeftBorder, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRightBorder)
        {
            transform.position = new Vector3(xRightBorder, transform.position.y, transform.position.z);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BeamBoy")
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("loaded");
            ScoreManager.ResetScore();
        }
    }
}
