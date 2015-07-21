using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public GameObject buttonResume;
	public GameObject buttonExit;
	public int pause;

	// Use this for initialization
	void Start () {
		buttonResume.SetActive (false);
		buttonExit.SetActive (false);
		pause = 0;
	
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Time.timeScale = 0;
			pause = 1;
			buttonResume.SetActive(true);
			buttonExit.SetActive (true);
		}
	}

	public void onClick(){
		Time.timeScale = 1;
		pause = 0;
		buttonResume.SetActive (false);
		buttonExit.SetActive (false);
	}

	public void onExit(){
		Application.Quit ();
	}
}
