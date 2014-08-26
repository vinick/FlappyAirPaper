using UnityEngine;
using System.Collections;

public class PencilColor : MonoBehaviour {
	
	public Color [] colors;
	
	// Use this for initialization
	void Start () {
		this.renderer.materials[0].color = colors[Random.Range(0, colors.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
