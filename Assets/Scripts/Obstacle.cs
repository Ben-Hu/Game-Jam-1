using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float speed = 1.0f;
	public int movement_direction = -1;
	private float speed_scaler = 0.01f;
	public enum Type {RESPONSIBILITES, CAT_TREAT, POWER_UP};
	public Type type = Type.RESPONSIBILITES;
	private GameObject camera;
	// Use this for initialization
	void Start () {
		speed_scaler *= movement_direction;
		camera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;
		transform.position = new Vector3 (pos.x, pos.y, pos.z + (0.4f*movement_direction) + (speed * speed_scaler));
		if (movement_direction > 0) {
			if (transform.position.z > camera.transform.position.z) {
				Destroy (this.gameObject);
			}
		} else {
			if (transform.position.z < camera.transform.position.z) {
				Destroy (this.gameObject);
			}
		}
	}

	public void setSpeed(float new_speed){
		speed = new_speed;
	}
}
