using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {
	private Player player;

	void Awake () {
		player = FindObjectOfType<Player> ().GetComponent<Player> ();
	}

	void Start(){
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("Hit");
			StartCoroutine (player.Knockback (0.02f, 1.5f, player.velocity));
		}
	}
}
