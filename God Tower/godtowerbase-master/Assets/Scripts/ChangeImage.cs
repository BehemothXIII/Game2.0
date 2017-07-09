using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {

	public GameObject Clue1;
	public GameObject Clue2;

	public bool switched;
	// Use this for initialization
	void Awake () {
		switched = true;
		Clue1.SetActive(true);
		Clue2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Switch(){
		switched = !switched;
		if (switched) {
			Clue1.SetActive(false);
			Clue2.SetActive (true);
		}
		else if (!switched) {
			Clue1.SetActive(true);
			Clue2.SetActive (false);
		}
	}


}
