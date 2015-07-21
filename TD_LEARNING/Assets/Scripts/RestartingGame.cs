using UnityEngine;
using System.Collections;

public class RestartingGame : MonoBehaviour {

	public void OnClick(){
		Application.LoadLevel ("Main");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}