using UnityEngine;
using System.Collections;

public class CreateTower : MonoBehaviour {
	public GameObject tower;
	public Transform buildplace;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				if (Physics.Raycast (ray, out hit)) {
					foreach (GameObject obj in GameObject.FindGameObjectsWithTag("BUILD")) {				
						if (hit.transform.position == obj.transform.position) {
							if (PlayerStats.gold >= 100) {
								Destroy (obj);
								GameObject newTower = Instantiate (tower, hit.transform.position, Quaternion.identity) as GameObject;
								PlayerStats.gold -= 100;
								newTower.GetComponent<TowerShoot>().spawnplace = GameObject.Find("SpawnPoint");
								return;
								
							}
						}	
					}
					foreach (GameObject towerUpgrade in GameObject.FindGameObjectsWithTag("Tower")){				
						if (hit.transform.position == tower.transform.position) {
							if (PlayerStats.gold >= 100){
								PlayerStats.gold -= 100;
								//towerUpgrade.GetComponent<TowerShoot>().upgrade += towerUpgrade.GetComponent<TowerShoot>().upgrade;
								towerUpgrade.GetComponent<TowerShoot>().damage += towerUpgrade.GetComponent<TowerShoot>().damage/2;
								return;
								
							}
						}	
					}
				}
			}
		}
#elif UNITY_STANDALONE
				if (Input.GetMouseButtonDown(0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					foreach (GameObject obj in GameObject.FindGameObjectsWithTag("BUILD")) {				
						if (hit.transform.position == obj.transform.position) {
							if (PlayerStats.gold >= 100) {
								Destroy (obj);
								GameObject newTower = Instantiate (tower, hit.transform.position, Quaternion.identity) as GameObject;
								PlayerStats.gold -= 100;
								newTower.GetComponent<TowerShoot>().spawnplace = GameObject.Find("SpawnPoint");
								return;
							}
						}	
					}
					foreach (GameObject towerUpgrade in GameObject.FindGameObjectsWithTag("Tower")){
						if (hit.transform.position == towerUpgrade.transform.position) {
							//int upgrade = towerUpgrade.GetComponent<TowerShoot>().upgrade;
							if (PlayerStats.gold >= 100) {
								PlayerStats.gold -= 100;
								//towerUpgrade.GetComponent<TowerShoot>().upgrade += towerUpgrade.GetComponent<TowerShoot>().upgrade;
								towerUpgrade.GetComponent<TowerShoot>().damage += towerUpgrade.GetComponent<TowerShoot>().damage/2;
								return;
							}
						}	
					}
				}
			}
#endif
	}
}