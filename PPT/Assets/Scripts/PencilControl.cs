using UnityEngine;
using System.Collections;

public class PencilControl : MonoBehaviour {
	
	public float createTimer;
	float timer;
	
	public Transform pencil;
	
	// Use this for initialization
	void Start () {
		timer = Time.time + createTimer;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameControl.startGame && !GameControl.death)
		{
			if(timer < Time.time)
			{
				Instantiate(pencil, new Vector3(this.transform.position.x, Random.Range(-4.01f, 4.01f), 0), Quaternion.identity);
				timer = Time.time + createTimer;
			}
		}
	
	}
}
