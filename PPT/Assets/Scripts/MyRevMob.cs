using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyRevMob : MonoBehaviour{
	
	bool showFullscreenAD;
	
	RevMobBanner banner;
	
	private static readonly Dictionary<string, string> REVMOB_APP_IDS = new Dictionary<string, string>()
	{
		{"Android", "52f69c1d746bc5a34800040c"},
		{"IOS", "ID"}
	};
	private RevMob revmob;
	
	void Awake()
	{
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		
		revmob = RevMob.Start(REVMOB_APP_IDS, this.gameObject.name);
		
		#endif
	}
	
	// Use this for initialization
	void Start () {
		showFullscreenAD = true;
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		banner = revmob.CreateBanner(RevMob.Position.TOP);
		//banner.Show();
		#endif
	
	}
	
	// Update is called once per frame
	void Update () {
		#if (UNITY_ANDROID && !UNITY_EDITOR)
		if(GameControl.startGame && showFullscreenAD)
		{
			showFullscreenAD = false;
			banner.Show();
		}
		#endif
		
	}
}
