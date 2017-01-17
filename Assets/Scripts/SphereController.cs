using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    public AudioSource audioSource;
    private audio audScript;
    private Rigidbody rb;
    public float speed, thrust;
    private int time;
    private float height;
    void Start()
    {
        audScript = audioSource.GetComponent<audio>();
        rb = GetComponent<Rigidbody>();
        height = 0;
        time = 0;
    }


    void FixedUpdate()
    {
        bool moveJump = Input.GetKeyDown("space");
        if(Input.GetKeyDown("space") && time == 0 && transform.position.y < 1.5)
        {
            audScript.playJump();
            height = 200.0f;
            time = 10;
        }
        else if (time > 0)
        {
            height = 200.0f;
            time--;
        }
        else
        {
            height = 0.0f;
        }

        Vector3 jump = new Vector3(0, height, 0);
        rb.AddForce(jump * speed);
        Vector3 movement = new Vector3(0.0f, 0.0f, thrust);
        transform.position += (movement * speed);

    }

  
}
