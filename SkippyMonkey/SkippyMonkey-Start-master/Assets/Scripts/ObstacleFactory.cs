using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour {
	public GameObject obstaclePrefab;
	public float startY;
	public float platformSpacing;
	public float platformGapHalfWidth;

	private int currentPlatformIndex = 0;
	private float gameHalfWidth;
	private float spawnHalfWidth;

	private List<GameObject> platformPool = new List<GameObject>();
	// Use this for initialization
	void Start () {
		spawnHalfWidth = Camera.main.orthographicSize * Camera.main.aspect - platformSpacing;
		CreatNewObstacleIfNeed ();

	}
	
	// Update is called once per frame
	void Update () {
		CreatNewObstacleIfNeed ();
		foreach (GameObject platform in platformPool) {
			if (platform.transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize) {
				platform.SetActive (false);
			}
		}
	}

	private GameObject GetNewPlatform(float positionY){
		foreach (GameObject platform in platformPool){
			if (!platform.activeInHierarchy) {
				platform.transform.position = new Vector3 (Random.Range (-spawnHalfWidth, spawnHalfWidth), positionY, 0);
				platform.SetActive (true);
				return platform;
			}
		}
		GameObject obstacle = Instantiate (
			                      obstaclePrefab, 
			                      new Vector3 (Random.Range (-spawnHalfWidth, spawnHalfWidth), positionY, 0), 
			                      Quaternion.identity);
		platformPool.Add (obstacle);
		return obstacle;
	}

	private void CreatNewObstacleIfNeed(){
		while (currentPlatformIndex * platformSpacing + startY < Camera.main.transform.position.y + Camera.main.orthographicSize) {
			GetNewPlatform (currentPlatformIndex * platformSpacing + startY);
			currentPlatformIndex++;
		}

	}
}
