using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {
	public float life;
	public GameObject spawnplace;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (life <= 0)
		{
			//Debug.Log("Enemies count = " + spawnplace.GetComponent<Spawn>().EnemiesList.Count);
			//Debug.Log("Remove result = " +  spawnplace.GetComponent<Spawn>().EnemiesList.Remove(gameObject));
			spawnplace.GetComponent<Spawn>().EnemiesList.Remove(gameObject);
			Destroy(this.gameObject);
			PlayerStats.gold += 10;
			PlayerStats.score += 1;
		}
	
	}


}
