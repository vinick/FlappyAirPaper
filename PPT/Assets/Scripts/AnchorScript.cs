using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AnchorScript : MonoBehaviour {
	
	public enum Anchor
    {
		/// <summary>Lower left</summary>
		LowerLeft,
		/// <summary>Lower center</summary>
		LowerCenter,
		/// <summary>Lower right</summary>
		LowerRight,
		/// <summary>Middle left</summary>
		MiddleLeft,
		/// <summary>Middle center</summary>
		MiddleCenter,
		/// <summary>Middle right</summary>
		MiddleRight,
		/// <summary>Upper left</summary>
		UpperLeft,
		/// <summary>Upper center</summary>
		UpperCenter,
		/// <summary>Upper right</summary>
		UpperRight,
    }
	
	public Anchor anchor = Anchor.UpperLeft;
	private Anchor oldAnchor = Anchor.UpperLeft;
	
	void Start () {
		Arrange();
	}
	
	void Update() {
		if(oldAnchor != anchor) {
			oldAnchor = anchor;
			Arrange();
		}
	}
	
	void Arrange() {
		Vector3 anchorPoint = Vector3.zero;
		if(anchor == Anchor.UpperLeft) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.MiddleLeft) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height/2,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.LowerLeft) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.UpperRight) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.MiddleRight) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height/2,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.LowerRight) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.UpperCenter) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.MiddleCenter) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		} else if(anchor == Anchor.LowerCenter) {
			anchorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0,  Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
		}
		transform.position = new Vector3(anchorPoint.x, anchorPoint.y, this.transform.position.z);
	}
}
