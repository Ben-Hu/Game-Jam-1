using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDirectionControl : MonoBehaviour {

    private Rigidbody rb;
    private float lastPos;
    public GameObject plane;
    public float catSpeed = 0.3f;
    public float catSpeedInterval = 10f;
    public float timeStamp;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lastPos = 0.0f;
        timeStamp = Time.time;
	}

    void OnAnimatorMove()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            Vector3 newPosition = transform.position;
            newPosition.z -= catSpeed;
            if (timeStamp + catSpeedInterval < Time.time)
            {
                catSpeed += catSpeed;
                timeStamp = Time.time + catSpeedInterval;
            }
            transform.position = newPosition;
        }
    }

    // Update is called once per frame
    void Update () {
       if (transform.position.z <= lastPos)
        {
            GameObject newPlane = Instantiate(plane, new Vector3(plane.transform.position.x, plane.transform.position.y, lastPos - 22.0f), Quaternion.identity);
            GameObject newPlane2 = Instantiate(plane, new Vector3(plane.transform.position.x, plane.transform.position.y, lastPos - 46.0f), Quaternion.identity);
            GameObject newPlane3 = Instantiate(plane, new Vector3(plane.transform.position.x, plane.transform.position.y, lastPos - 70.0f), Quaternion.identity);
            GameObject newPlane4 = Instantiate(plane, new Vector3(plane.transform.position.x, plane.transform.position.y, lastPos - 94.0f), Quaternion.identity);
            Destroy(newPlane, 15);
            Destroy(newPlane2, 15);
            Destroy(newPlane3, 15);
            Destroy(newPlane4, 15);
            lastPos -= 92.0f;
        }
	}
}


