using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
	
	public float gravity;
	public float airForce;
	
	public float forceGravity;
	
	bool down;
	float defaultGravity;
	
	public CharacterController plane;
	
	float timeToRot;
	bool rot;
	
	public AudioClip click;
	bool canDie;
	float timeToDie;
	
	public Transform planeObj;
	
	float canStartGameTime;
	bool canStartGame;
	
	
	// Use this for initialization
	void Start () {
		canDie = true;
		down = true;
		defaultGravity = gravity;
		timeToDie = Time.time;
		
		canStartGameTime = Time.time + 0.5f;
		canStartGame = false;
		
		planeObj.animation.Play("idle");
		
		planeObj.animation["asas"].wrapMode = WrapMode.Once;
		planeObj.animation["asas"].speed = 0.2f;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameControl.startGame && !GameControl.death)
		{
			if(down && timeToRot < Time.time)
			{
				if(rot)
				{
					iTween.RotateTo(this.gameObject, iTween.Hash(
						"rotation", new Vector3(0, 15, -35),
						"time", 1f,
						"easetype", iTween.EaseType.easeInCubic
						));
					rot = false;
				}
				plane.Move(Vector3.down * gravity * Time.deltaTime);
				gravity += forceGravity;
			}
			else if(!down)
			{
				audio.clip = click;
				audio.Play();
				
				iTween.Stop(this.gameObject);
				//this.transform.localRotation = Quaternion.Euler(0, 0, 25);
				iTween.RotateTo(this.gameObject, iTween.Hash(
						"rotation", new Vector3(0, 0, 35),
						"time", 0.1f,
						"easetype", iTween.EaseType.linear
						));
				//plane.Move(Vector3.up * airForce * Time.deltaTime);
				iTween.MoveTo(this.gameObject, iTween.Hash(
					"position", new Vector3(-2.3f, this.transform.position.y + airForce, 12),
					"time", 0.1f,
					"easetype", iTween.EaseType.linear,
					"islocal", true
					));
				gravity = defaultGravity;
				down = true;
				rot = true;
				timeToRot = Time.time + 0.1f;
			}
			
			if(Input.GetKeyDown(KeyCode.Space) || Tap.touch)
			{
				Tap.touch = false;
				planeObj.animation.CrossFade("asas");
				down = false;
			}
		}
		else if((Input.GetKeyDown(KeyCode.Space) || Tap.touch) && !GameControl.death && canStartGame)
		{
			if(!GameControl.startGame)
			{
				GameControl.startGame = true;
			}
			Tap.touch = false;
			planeObj.animation.CrossFade("asas");
			down = false;
		}
		
		if(canStartGameTime < Time.time && !canStartGame)
		{
			Tap.touch = false;
			canStartGame = true;
		}
		
		
		
		if(GameControl.death && canDie && timeToDie < Time.time)
		{
			canDie = false;
			iTween.RotateTo(this.gameObject, iTween.Hash(
						"rotation", new Vector3(0, 15, -60),
						"time", 0.4f,
						"easetype", iTween.EaseType.linear
						));
			iTween.MoveTo(this.gameObject, iTween.Hash(
					"position", new Vector3(-2.3f, -5, 10),
					"time", 0.4f,
					"easetype", iTween.EaseType.linear,
					"islocal", true
					));
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "lapis" && !GameControl.death)
		{
			iTween.Stop(this.gameObject);
			timeToDie = Time.time + 0.1f;
			GameControl.death = true;
		}
		
		if(other.tag == "ponto")
		{
			Destroy(other.gameObject);
			GameControl.score++;
			ScoreSound.sound = true;
		}
		
		if(other.tag == "extraCollider" && !GameControl.death)
		{
			iTween.Stop(this.gameObject);
			GameControl.death = true;
			canDie = false;
		}
	}
	
}
