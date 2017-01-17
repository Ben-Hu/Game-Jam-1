using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private float distanceH, distanceV;
    private float boxH, boxV, speedChange;
    public Text scoreText;
    int score = 0;
    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
        distanceH = 0;
        distanceV = 0;
        speedChange = 0;
        boxH = 3.6f;
        boxV = 3.0f;
        scoreText.text = "";
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        score++;
        float moveV = Input.GetAxis("Vertical") * 0.3f;
        Vector3 movementV;
        if ((distanceV + moveV <= boxV) && (distanceV + moveV >= -boxV))
        {
            distanceV += moveV;
            movementV = new Vector3(0.0f, 0.0f, moveV);
        }else
        {
            movementV = new Vector3(0.0f, 0.0f, 0.0f);
        }

        float moveH = Input.GetAxis("Horizontal") * 0.3f;
        Vector3 movementH;
        if ((distanceH + moveH <= boxH) && (distanceH + moveH >= -boxH))
        {
            distanceH += moveH;
            movementH = new Vector3(moveH, 0.0f, 0.0f);
        }
        else
        {
            movementH = new Vector3(0.0f, 0.0f, 0.0f);
        }
        Vector3 speedTemp = new Vector3(0.0f, 0.0f, speedChange);
        offset += movementH + movementV - speedTemp;
        transform.position = player.transform.position + offset;
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Debug.Log("HIT");
        if (other.gameObject.CompareTag("Good"))
        {
            speedChange += 0.02f;
        }
        else if (other.gameObject.CompareTag("Bad"))
        {
            speedChange -= 0.2f;
        }
        else
        {
            SetScoreText();
        }
        if(speedChange > 0.2)
        {
            speedChange = 0.2f;
        }
        if (speedChange < -0.2)
        {
            speedChange = -0.2f;
        }
    }
    bool finished = false;
    void SetScoreText()
    {
        if (finished == false)
        {
            scoreText.text = "Score: " + score;
            finished = true;
        }
    }
}
