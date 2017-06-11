using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float playerSpeed;
	public float jumpSpeed;
	private Rigidbody2D rgbody;
	private Animator anim;
	public static float SCREEN_HALF_WITH = 320F;
	// Use this for initialization
	void Start () {
		rgbody = GetComponent<Rigidbody2D> ();
		rgbody.velocity = rgbody.velocity.WithX (playerSpeed);
		anim = GetComponent<Animator> ();
		LeanTouch.OnFingerTap += Jump;
	}
	void OnDestroy(){
		LeanTouch.OnFingerTap -= Jump;
	}
	// Update is called once per frame
	void Update () {
		rgbody.velocity = rgbody.velocity.WithX (playerSpeed);
		if (transform.position.x > SCREEN_HALF_WITH) {
			transform.position = transform.position.WithX (transform.position.x - 2 * SCREEN_HALF_WITH);
		}
	}

	private void Jump(LeanFinger finger)
	{
			rgbody.velocity = rgbody.velocity.WithY (jumpSpeed);
			anim.SetBool ("isGrounded", false);
	}

	void OnCollisionEnter2D(Collision2D col){
		
			anim.SetBool ("isGrounded", true);
	}
}
