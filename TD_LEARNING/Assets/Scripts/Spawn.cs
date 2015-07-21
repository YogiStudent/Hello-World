using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Spawn : MonoBehaviour {
	public GameObject mob;
	public float delay;
	public List<GameObject> EnemiesList;
	private DateTime timer;
	private DateTime total;
	public float life;
	public float acc;
	public GameObject mainController;


	// Use this for initialization
	void Start () {
		timer = DateTime.Now;
		delay = 1.0f;
		total = DateTime.Now;	
		life = 100;
		acc = 2;

	}
	
	// Update is called once per frame
	void Update () {
		if (mainController.GetComponent<Pause> ().pause == 0) {

			TimeSpan ts = DateTime.Now - timer;
			TimeSpan tester = DateTime.Now - total;
			if (ts.TotalSeconds >= delay) {
				if (tester.TotalSeconds >= 20) {
					delay -= (delay / 10);
					life += (life / 2);
					acc += (acc / 2);
					total = DateTime.Now;
				}
				SpawnEnemy();
				timer = DateTime.Now;

			}
		}

	
	}

	void SpawnEnemy(){
		GameObject newEnemy =  Instantiate (mob, transform.position, Quaternion.identity) as GameObject;
		newEnemy.GetComponent<EnemyStats> ().life = life;
		newEnemy.GetComponent<EnemyMovement> ().acc = acc;
		newEnemy.GetComponent<EnemyStats> ().spawnplace = this.gameObject;
		EnemiesList.Add (newEnemy);

	}

}