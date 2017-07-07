using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaController : MonoBehaviour {
	public static BananaController _instance {
		get;
		private set;
	}
	public static float score;

	void Start(){
		score = 0;
	}
	private void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Score.Scoring ();
			Destroy (gameObject);

		}
	}


}
