using UnityEngine;
using System.Collections;

public class RocketDestroyer : MonoBehaviour {
	public GameObject tower;
	public float damage;

	void Start(){
		//damage = tower.GetComponent<TowerShoot>().damage;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<EnemyStats>().life -= damage;
			Destroy(this.gameObject);
		}
		Destroy (this.gameObject, 1.5f);
	}
}
