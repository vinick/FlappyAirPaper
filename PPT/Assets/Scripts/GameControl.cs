using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	
	public static bool startGame;
	public static bool death;
	public float speed;
	
	public Transform airPaperLogo;
	bool logo;
	public Transform tap;
	
	public static int score;
	public tk2dTextMesh scoreText;
	bool scoreAppear;
	bool scoreDisappear;
	
	public Transform gameOver;
	public AudioClip gameOverSound;
	public AudioClip backgroundSound;
	
	public Transform bgTransp;
	public Transform bgPos;
	
	public tk2dTextMesh finalScoreText;
	public tk2dTextMesh bestScoreText;
	float finalScore;
	int bestScore;
	bool canFinalScore;
	
	public static bool canRestart;
	
	public Transform info;
	
	// Use this for initialization
	void Start () {
		
		score = 0;
		startGame = false;
		death = false;
		logo = false;
		scoreAppear = false;
		scoreDisappear = false;
		canFinalScore = false;
		canRestart = false;
		
		if(!PlayerPrefs.HasKey("bestScore"))
		{
			PlayerPrefs.SetInt("bestScore", 0);
		}
		
		bestScore = PlayerPrefs.GetInt("bestScore");
		bestScoreText.text = bestScore.ToString();
		bestScoreText.Commit();
	}
	
	// Update is called once per frame
	void Update () {
		if(startGame && !death)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			logo = true;
			
			if(!scoreAppear)
			{
				audio.clip = backgroundSound;
				audio.loop = true;
				audio.Play();
				
				iTween.MoveTo(scoreText.gameObject, iTween.Hash(
					"position", new Vector3(0, 3, 8),
					"time", 1,
					"islocal", true,
					"easetype", iTween.EaseType.easeOutBounce
					));
				scoreAppear = true;
			}
			
			if(bgTransp.renderer.material.color.a > 0)
			{
				Color myColor = bgTransp.renderer.material.color;
				myColor.a -= 1 * Time.deltaTime;
				bgTransp.renderer.material.color = myColor;
			}
			else if(bgTransp.renderer.material.color.a <= 0)
			{
				bgTransp.position = bgPos.position;
			}
		}
		
		if(death)
		{
			
			if(canFinalScore)
			{
				if(finalScore < score)
				{
					finalScore += 0.5f;
					finalScoreText.text = ((int)finalScore).ToString();
					finalScoreText.Commit();
				}
				else
				{
					if(bestScore < finalScore)
					{
						bestScore = (int)finalScore;
						PlayerPrefs.SetInt("bestScore", bestScore);
						bestScoreText.text = bestScore.ToString();
						bestScoreText.Commit();
					}
					canRestart = true;
				}
			}
			
			if(bgTransp.renderer.material.color.a < 0.6f)
			{
				Color myColor = bgTransp.renderer.material.color;
				myColor.a += 1 * Time.deltaTime;
				bgTransp.renderer.material.color = myColor;
			}
			
			if(!scoreDisappear)
			{
				audio.clip = gameOverSound;
				audio.loop = false;
				audio.Play();
				
				iTween.MoveTo(scoreText.gameObject, iTween.Hash(
					"position", new Vector3(0, 8, 8),
					"time", 0.5f,
					"islocal", true,
					"easetype", iTween.EaseType.linear
					));
				
				iTween.MoveTo(gameOver.gameObject, iTween.Hash(
					"position", new Vector3(0, 0.5f, 8),
					"time", 1,
					"islocal", true,
					"easetype", iTween.EaseType.easeOutBounce,
					"delay", 0.5f,
					"oncompletetarget", this.gameObject,
					"oncomplete", "FinalScore"
					));
				
				scoreDisappear = true;
			}
		}
		
		if(logo)
		{
			airPaperLogo.Translate(Vector3.right * Time.deltaTime * 15, Space.Self);
			tap.renderer.enabled = false;
		}
		
		scoreText.text = score.ToString();
		scoreText.Commit();
	
	}
	
	void FinalScore()
	{
		canFinalScore = true;
		info.gameObject.SetActive(true);
	}
}
