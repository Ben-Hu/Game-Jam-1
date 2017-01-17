using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleGenerator : MonoBehaviour {

	public int MAX_GENERATION_TIME = 4;
	public int MIN_GENERATION_TIME = 2;
    public int MAX_GENERATION_SPEED = 3;
    public int MIN_GENERATION_SPEED = 1;
    public int movement_direction = -1;
	public float speed = 5.0f;
	public float speed_scaler = 0.01f;

	private float gen_time_scaler = 0.1f; 
	private bool is_generating = false;
	private float time_stamp = 0.0f;
	private float width;
	private const int text_list_size = 11; 
	private string[] responsibilities_text_array = {"JOBS", "BABY", "ALCHOHOLISM", "GPA", "LAWS", "ART", "NOT ENOUGH DIP", "LINE-UPS", "THE MAN", "MORE SLEEP", "DENTIST"};
	private List<string> responsibilities_text = new List<string> (); 

	// Use this for initialization
	void Start () {
		width = transform.GetComponent<Renderer> ().bounds.size.x;
		for (int i = 0; i < text_list_size; i++) {
			responsibilities_text.Add (responsibilities_text_array [i]);
		}
		speed_scaler *= movement_direction;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(is_generating){
			if (Time.time > time_stamp) {
				generateObstacle ();
				is_generating = false;
			}
		}else{
			int rand_time = Random.Range (MIN_GENERATION_TIME, MAX_GENERATION_TIME);
			time_stamp = Time.time + rand_time;
			is_generating = true;
		}

	}

	private void generateObstacle(){
		int r_type = Random.Range (0, 9);
		if(r_type > 7){
			//Cat-treat
			createObstacle("Cat Treat");
		}else if(r_type > 1){
			// Responsibility
			createObstacle("Responsibilities");
		}else{
			// Power-up
			createObstacle("Power-up");
		}
	}

	private void createObstacle(string name){
		GameObject obstacle = (GameObject)GameObject.Instantiate (Resources.Load ("Prefabs/" + name));
		Obstacle obstacle_script = obstacle.transform.GetComponent<Obstacle> ();
		int r_speed = Random.Range (MIN_GENERATION_SPEED, MAX_GENERATION_SPEED);
		obstacle_script.setSpeed (r_speed);
		int r_posx = Random.Range ((int)(transform.position.x - width / 2), (int)(transform.position.x + width / 2));
		obstacle.transform.position = new Vector3 (r_posx, transform.position.y, transform.position.z);

		if (name == "Responsibilities") {
			GameObject text_obj = (GameObject)GameObject.Instantiate (Resources.Load ("Prefabs/Text_Object"));
			TextMesh text = text_obj.transform.FindChild("text").gameObject.GetComponent<TextMesh>();
			int rand_text = Random.Range(0, responsibilities_text.Count - 1);
			text.text = responsibilities_text [rand_text];
			text_obj.transform.position = obstacle.transform.position;
			float text_width = 0;
			foreach (char symbol in text.text) {
				CharacterInfo info;
				if (text.font.GetCharacterInfo (symbol, out info, text.fontSize, text.fontStyle)) {
					text_width += info.advance;
				}
			}
			text_width *= text.characterSize * 0.05f;
			Debug.Log (text_width);
			float obstacle_scale_x = text_width / obstacle.transform.GetComponent<Renderer> ().bounds.size.x;
			obstacle.transform.localScale = new Vector3(obstacle_scale_x, obstacle.transform.localScale.y, obstacle.transform.localScale.z);
			/*obstacle.transform.GetComponent<Renderer> ().bounds.size.Set(text_obj.transform.GetComponent<Renderer> ().bounds.size.x,
				obstacle.transform.GetComponent<Renderer> ().bounds.size.y,
				obstacle.transform.GetComponent<Renderer> ().bounds.size.z);*/
			text_obj.transform.parent = obstacle.transform;
		}
	}
}
