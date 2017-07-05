using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	
	public Vector2 direction{ get; private set; }
	void Update(){
		direction = new Vector2 (Input.GetAxis ("Horizontal"),0);
	}
}
