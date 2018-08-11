using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	// Use this for initialization

	// Defining Rigidbody Variable player
	private Rigidbody player;
	private AudioSource audio_obstacle;

	// Define a public variable for speed
	public float speed;

	// Define a game object For Camera
	public GameObject camera;
	public GameObject myplayer;
	public Vector3 offset;

	// Set the next Scene
	public int scene;
	// Set The Score
	private int score;
	private int life = 100;

	// Set the text in the text box
	public Text score_text;
	public Text life_text;

	public AudioClip audioclip_obstacle;
	public AudioClip audioclip_collectitem;

	void Start () 
	{
		// Initialize player variable

		player = GetComponent<Rigidbody> ();
		audio_obstacle = GetComponent<AudioSource> ();
		score = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		// Get input from users as vertical and horizontal
		var horizontal = Input.GetAxis ("Horizontal");
		var vertical = Input.GetAxis ("Vertical");

		// Use Vector3 to set the player movement

		Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);
		player.AddForce (movement*speed);
	}
	void LateUpdate()
	{
		camera.transform.position = player.transform.position + offset;
	}

	// On Collision 
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "collect_items")
		{
			audio_obstacle.PlayOneShot (audioclip_collectitem);
			Destroy (col.gameObject);
			score = score + 100;
			score_text.text = "Score : "+score.ToString();
			if(score>=400)
			{
				SceneManager.LoadScene (scene);
			}
		}
		if(col.gameObject.tag == "danger_obstacle")
		{
			audio_obstacle.PlayOneShot (audioclip_obstacle);
			life = life - 20;
			if(life<=0)
			{
				life_text.text = "Life : 0 %";
				DestroyMyPlayer ();
				SceneManager.LoadScene (5);
			}
			else
			{
				life_text.text = "Life : "+life.ToString()+" %";
			}
		}
		if(col.gameObject.tag == "animate_obstacle")
		{
			audio_obstacle.PlayOneShot (audioclip_obstacle);
			life = life - 25;
			if(life<=0)
			{
				life_text.text = "Life : 0 %";
				DestroyMyPlayer ();
				SceneManager.LoadScene (5);
			}
			else
			{
				life_text.text = "Life : "+life.ToString()+" %";
			}
		}
	}

	void DestroyMyPlayer()
	{
		Destroy (myplayer);
	}
}
