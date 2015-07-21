using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
	public static float playerLife;
	public Text lifeCount;
	public static int gold;
	public Text goldCount;
	public static int score;
	public Text scoreCount;

	// Use this for initialization
	void Start () {
		playerLife = 1000;
		gold = 100;
		score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		ShowLife ();
		ShowGold ();
		ShowScore ();
		if (playerLife <= 0) {
			Application.LoadLevel("Main Menu");
		}
	}
	void ShowLife(){
		lifeCount.text = "Life: " + playerLife.ToString ();
	}

	void ShowGold(){
		goldCount.text = "Gold: " + gold.ToString ();
	}

	void ShowScore(){
		scoreCount.text = "Score: " + score.ToString ();
	}

}
