using UnityEngine;
using System.Collections;

public class DestroyPencil : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "lapis")
		{
			Destroy(other.gameObject);
		}
	}
}
