using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour {


public AudioClip jump;
public AudioClip hit;
public AudioClip lose;
public AudioClip bubble;
public AudioClip music;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



	}
	
	public void playJump (){
		GetComponent<AudioSource>().PlayOneShot(jump, 1.0f);
	}
	public void playBubble (){
		GetComponent<AudioSource>().PlayOneShot(bubble, 1.0f);
	}
	public void playHit (){
		GetComponent<AudioSource>().PlayOneShot(hit, 1.0f);
	}
	public void playLose (){
		GetComponent<AudioSource>().PlayOneShot(lose, 1.0f);
	}
	
}
