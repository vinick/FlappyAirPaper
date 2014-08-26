using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {
	
	public static bool touch;
	public Transform restart;
	public Transform touchCollider;
	public Transform info;
	public Transform thanks;
	
	// Use this for initialization
	void Start () {
		touch = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameControl.death)
		{
			touchCollider.gameObject.SetActive(false);
		}
	
	}
	
	void OnEnable(){
		EasyTouch.On_TouchStart += On_SimpleTap;
	}

	void OnDisable(){
		UnsubscribeEvent();
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_TouchStart -= On_SimpleTap;	
	}
	
	private void On_SimpleTap( Gesture gesture){		
		if (gesture.pickObject == touchCollider.gameObject)
		{
			touch = true;
		}
		
		if(gesture.pickObject == restart.gameObject)
		{
			Application.LoadLevel("MainScene");
		}
		
		if (gesture.pickObject == info.gameObject)
		{
			thanks.gameObject.SetActive(true);
		}
	}
}
