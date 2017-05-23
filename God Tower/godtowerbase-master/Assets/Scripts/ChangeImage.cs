using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {
//	public Image image1;
//	public Image image2;
//
//	public Button nextButton;
//	public Button backButton;

	public GameObject Clue1;
	public GameObject Clue2;

	public bool switched;
	// Use this for initialization
	void Awake () {
		switched = true;
//		image1.gameObject.SetActive (true);
//		image2.gameObject.SetActive (false);
//		nextButton.gameObject.SetActive(true);
//		backButton.gameObject.SetActive(false);
		Clue1.SetActive(true);
		Clue2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Switch(){
		switched = !switched;
		if (switched) {
//			image1.gameObject.SetActive (false);
//			image2.gameObject.SetActive (true);
//			nextButton.gameObject.SetActive(false);
//			backButton.gameObject.SetActive(true);
			Clue1.SetActive(false);
			Clue2.SetActive (true);
		}
		else if (!switched) {
//			image1.gameObject.SetActive (true);
//			image2.gameObject.SetActive (false);
//			nextButton.gameObject.SetActive(true);
//			backButton.gameObject.SetActive(false);
			Clue1.SetActive(true);
			Clue2.SetActive (false);
		}
	}


}
