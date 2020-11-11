using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    public static float speed;
    public static float startSpeed = 10.0f;
    public static float maxSpeed = 90.0f;

    // Update is called once per frame
    void Update()
    {
        //new Vector3(0,1,0) same as Vector3.up
        //need time.deltatime with speed. timedeltatime(time between frames) averages frames so fast computers dont go faster
        //space.world is to move it relative to world instead of the object

        //yo david its evan gabriel said you would give her shit for having notes in comments. i told her its ok. :)
        //if youre not david then ignore the previous comment ;)
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);

        if(this.gameObject.transform.localPosition.y >= 0)
        {
            Destroy(this.gameObject);
            ScoreManager.score ++;
        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject.tag);
    //    if (other.gameObject.tag == "Plane")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //    if (collision.gameObject.tag == "Plane")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
