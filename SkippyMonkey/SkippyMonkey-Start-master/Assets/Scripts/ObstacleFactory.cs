using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour {
	public GameObject obstaclePrefab;
	// Use this for initialization
	void Start () {
		for (int y = -195; y < 450; y += 200) {
			Vector2 position = new Vector2 (Random.Range (-310, 310), y);
			GameObject obstacle = Instantiate (obstaclePrefab, position, Quaternion.identity) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
