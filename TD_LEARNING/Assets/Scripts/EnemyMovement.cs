using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public Transform target;
	NavMeshAgent agent;
	public GameObject spawnplace;
	public float acc;

	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.acceleration = acc;
		agent.SetDestination (target.position);

	}
	
	// Update is called once per frame
	void Update () {
		if (acc < 2) {
			agent.acceleration = 2;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "KillPoint") {
			spawnplace.GetComponent<Spawn>().EnemiesList.Remove(this.gameObject);
			Destroy (this.gameObject);
			PlayerStats.playerLife -= GetComponent<EnemyStats>().life;
		}
	}
}