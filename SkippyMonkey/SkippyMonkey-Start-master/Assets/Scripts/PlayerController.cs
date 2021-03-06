using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;


public class PlayerController : MonoBehaviour {

	public float playerSpeed;
	public float jumpSpeed;
	public float jumpHeight = 4;
	public float timeToJumpApex = 0.4f; 
	/// <summary>
	/// The acceleration time airborne.
	/// </summary>
	public float accelerationTimeAirborne = 0.2f ;   
	/// <summary>
	/// The acceleration time grounded.
	/// </summary>
	public float accelerationTimeGrounded = 0.1f ;  ///
	float gravity;
	float jumpVelocity;

//	private Rigidbody2D rgbody;
	private Animator anim;
	private Vector2 velocity;
	public bool die = false;
	float velocityXSmoothing;

	public static float SCREEN_HALF_WITH = 320F;
	Controller2D controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D> ();
//		rgbody = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();
		LeanTouch.OnFingerTap += Jump;
		gravity = -(2*jumpHeight)/Mathf.Pow(timeToJumpApex,2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;

	}
	void OnDestroy(){
		LeanTouch.OnFingerTap -= Jump;
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		if (!controller.collision.collideTop && !controller.collision.collideRight) {
			Vector2 input = Vector2.right;
			float targetVelocityX = input.x * playerSpeed;
			velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collision.collideBottom) ? accelerationTimeGrounded : accelerationTimeAirborne);
			velocity.y += gravity * Time.fixedDeltaTime;
			controller.Move(velocity * Time.fixedDeltaTime);
			anim.SetBool ("isGrounded", true);
		}

		if (transform.position.x > SCREEN_HALF_WITH) {
			transform.position = transform.position.WithX (transform.position.x - 2 * SCREEN_HALF_WITH);
		}

		if (controller.collision.collideTop || controller.collision.collideBottom || controller.collision.collideRight) {
			velocity.y = 0;
		}

		if (controller.collision.collideTop || controller.collision.collideRight) {
			Die ();
		}
		if(!controller.collision.collideBottom){
			anim.SetBool ("isGrounded", false);
		}
	}

	private void Jump(LeanFinger finger)
	{
		
		if (controller.collision.collideBottom) {
			velocity.y = jumpVelocity;
			controller.collision.collideBottom = false;
		}

//			rgbody.velocity = rgbody.velocity.WithY (jumpSpeed);

	}

	public void Die(){
		Debug.Log ("Die");
		die = true;
		TKSceneManager.ChangeScene ("End Scene");
	}
}
