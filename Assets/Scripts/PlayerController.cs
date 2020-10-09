using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;

    [SerializeField]
    public float speed = 10.0f;

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
    }
}
