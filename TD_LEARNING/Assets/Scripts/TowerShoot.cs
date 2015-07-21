using UnityEngine;
using System.Collections;
using System;


public class TowerShoot : MonoBehaviour {
	public float damage = 30f;
	private DateTime lastshoot;
	public GameObject spawnplace;
	public Rigidbody rocket;
	public Transform towerEnd;
	//public int upgrade;


	// Use this for initialization
	void Start () {
		lastshoot = DateTime.Now;
//		upgrade = 200;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider enemy){

		if (enemy.gameObject.CompareTag ("Enemy")) {
			Vector3 targetDir = enemy.transform.position - transform.position;
			Vector3 targetDirXZ = new Vector3(targetDir.x, transform.position.y, targetDir.z);
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDirXZ, 100, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
			TimeSpan ts = DateTime.Now - lastshoot;
			if (ts.TotalSeconds > 0.2)
			{
				foreach(GameObject enemyObject in spawnplace.GetComponent<Spawn>().EnemiesList){
					if (enemyObject == enemy.gameObject)
					{

						Rigidbody rocketInstance;
						rocketInstance = Instantiate(rocket, towerEnd.position, towerEnd.rotation) as Rigidbody;
						rocketInstance.AddForce(transform.forward * 3000);
						rocketInstance.GetComponent<RocketDestroyer>().damage = damage;
					}
				}
				lastshoot = DateTime.Now;
			}
		}
	}

}