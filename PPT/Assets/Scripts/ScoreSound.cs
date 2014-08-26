using UnityEngine;
using System.Collections;

public class ScoreSound : MonoBehaviour {
	
	public static bool sound;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(sound)
		{
			sound = false;
			audio.Play();
		}
	
	}
}
