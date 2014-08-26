using UnityEngine;
using System.Collections;

public class ScoreOutline : MonoBehaviour {
	
	tk2dTextMesh score;
	public tk2dTextMesh scoreOutline;
	
	
	// Use this for initialization
	void Start () {
		score = GetComponent<tk2dTextMesh>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		scoreOutline.text = score.text;
		scoreOutline.Commit();
	
	}
}
