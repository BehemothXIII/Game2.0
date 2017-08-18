using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = .4f;
    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;
    private float moveSpeed = 6f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

	public bool facingRight;
	public bool jump;
    public bool canDoubleJump;
    private bool isDoubleJumping = false;

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = .25f;
    private float timeToWallUnstick;

    private float gravity;
    private float maxJumpVelocity;
    private float minJumpVelocity;
	public Vector3 velocity;
    private float velocityXSmoothing;

    private Controller2D controller;
	private BoxCollider2D b2d;
	private Animator anim;
	private SpriteRenderer sprite;

    private Vector2 directionalInput;
    private bool wallSliding;
    private int wallDirX;

    private void Start()
    {
		facingRight = true;
        controller = GetComponent<Controller2D>();
		b2d = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();
		sprite = GetComponent<SpriteRenderer>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    private void Update()
    {
        CalculateVelocity();
//        HandleWallSliding();
		controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0f;
			anim.SetBool ("jump", false);
        }


    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
		if (directionalInput.x > 0 && !facingRight) {
			Flip ();
		} else if (directionalInput.x < 0 && facingRight) {
			Flip ();
		}
		anim.SetFloat ("walk", Mathf.Abs(directionalInput.x));
    }

    public void OnJumpInputDown()
    {
		anim.SetBool ("jump", true);	
        if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
            isDoubleJumping = false;
        }
        if (controller.collisions.below)
        {
			velocity.y = maxJumpVelocity;
            isDoubleJumping = false;
        }
        if (canDoubleJump && !controller.collisions.below && !isDoubleJumping && !wallSliding)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = true;
        }
    }

    public void OnJumpInputUp()
    {
		
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }


//    private void HandleWallSliding()
//    {
//        wallDirX = (controller.collisions.left) ? -1 : 1;
//        wallSliding = false;
//        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
//        {
//            wallSliding = true;
//
//            if (velocity.y < -wallSlideSpeedMax)
//            {
//                velocity.y = -wallSlideSpeedMax;
//            }
//
//            if (timeToWallUnstick > 0f)
//            {
//                velocityXSmoothing = 0f;
//                velocity.x = 0f;
//                if (directionalInput.x != wallDirX && directionalInput.x != 0f)
//                {
//                    timeToWallUnstick -= Time.deltaTime;
//                }
//                else
//                {
//                    timeToWallUnstick = wallStickTime;
//                }
//            }
//            else
//            {
//                timeToWallUnstick = wallStickTime;
//            }
//        }
//    }

    private void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below ? accelerationTimeGrounded : accelerationTimeAirborne));
        velocity.y += gravity * Time.deltaTime;
		anim.SetFloat ("verticalSpeed", velocity.y);
    }

	private void Flip (){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	public void Die(){
		TKSceneManager.ChangeScene ("Start Scene");
	}
		
	public IEnumerator Knockback(float KnockDur, float KnockPwr, Vector3 KnockDir){
		float timer = 0;
		velocity = new Vector3 (0, 0, 0);
		while (KnockDur > timer) {
			timer += Time.deltaTime;
			velocity.x = KnockDir.x * -2;
			velocity.y = -KnockDir.y * KnockPwr;
			b2d.enabled = false;
		}
		yield return new WaitForSeconds (1f);
		Die ();
		yield return 0;
	}
}
