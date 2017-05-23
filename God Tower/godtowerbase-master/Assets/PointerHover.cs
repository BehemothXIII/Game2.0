using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerHover : MonoBehaviour {

	Image image;
	// Use this for initialization
	void Start () {
		image = gameObject.GetComponent<Image> ();
	}
	
	public void OnPointerEnter(){
		Color colorImage = image.color;
		colorImage.a = 0;
		image.color = colorImage;
	}

	public void OnPointerExit(){
		Color colorImage = image.color;
		colorImage.a = 1;
		image.color = colorImage;
	}
}
