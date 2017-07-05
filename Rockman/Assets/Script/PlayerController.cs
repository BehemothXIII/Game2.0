using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private InputController inputController;
	private Controller2D controller2D;
	private Vector2 velocity;
	public float movementSpeed;

	private void Awake(){
		inputController = GetComponent<InputController> ();
		controller2D = GetComponent<Controller2D> ();
	}
	private void FixedUpdate(){
		velocity = new Vector2 (inputController.direction.x * movementSpeed, velocity.y + Physics2D.gravity.y * Time.fixedDeltaTime);

		PlayerStatus playerStatus = controller2D.Move (velocity*Time.fixedDeltaTime);
		transform.position += (Vector3)playerStatus.velocity;
//		Debug.Log (velocity.x + " " + velocity.y+ " ");

	}
}
