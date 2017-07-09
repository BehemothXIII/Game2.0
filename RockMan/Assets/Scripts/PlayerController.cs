using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour {
    public float movementSpeed;
    public float jumpSpeed;


	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public float wallSlideSpeedMax;
	public float wallStickTime;
	bool wallSliding;
	int wallDirX;
	float timeToWallUnstick;

    [Space]
    public float dashMultiplier;
    public float dashTime;


    public bool airborneSkillAvailable { get; private set; }
    public bool isDashing { get; private set; }


    private InputController inputController;
    private Controller2D controller2D;
    private Vector2 velocity;
	private Vector2 oldGravity;
    private int faceDirection;

    public PlayerStatus playerStatus { get; private set; }

    private void Awake()
    {
        inputController = GetComponent<InputController>();
        controller2D = GetComponent<Controller2D>();

        inputController.OnMovePressed += Move;
        inputController.OnJumpPressed += JumpIfPossible;
        inputController.OnDashPressed += DashIfPossible;
    }

	private void OnDestroy()
    {
        inputController.OnMovePressed -= Move;
        inputController.OnJumpPressed -= JumpIfPossible;
        inputController.OnDashPressed -= DashIfPossible;
    }

    private void FixedUpdate()
    {
		velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        playerStatus = controller2D.Move(velocity * Time.fixedDeltaTime);

        transform.position += (Vector3)playerStatus.velocity;

        if (playerStatus.isCollidingBottom || playerStatus.isCollidingTop)
        {
            velocity.y = 0;
        }

        if (playerStatus.isCollidingBottom) airborneSkillAvailable = true;

		wallDirX = (playerStatus.isCollidingLeft) ? -1 : 1;
		wallSliding = false;
		if ((playerStatus.isCollidingLeft || playerStatus.isCollidingRight) 
			&& !playerStatus.isCollidingBottom && velocity.y < 0) 
		{
			wallSliding = true;
			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = -wallSlideSpeedMax;
			}
			if (timeToWallUnstick > 0) {
				velocity.x = 0;
				if (faceDirection != wallDirX && faceDirection != 0) {
					timeToWallUnstick -= Time.fixedDeltaTime;
				} 
				else {
					timeToWallUnstick = wallStickTime;
				}
			}
			else {
				timeToWallUnstick = wallStickTime;
			}
		}
    }

    public void ActivateAirborneSkill()
    {
        airborneSkillAvailable = false;

    }


    private void JumpIfPossible()
    {
		if (wallSliding) {
			if (wallDirX == faceDirection) {
				velocity.x = -wallDirX * wallJumpClimb.x;
				velocity.y = wallJumpClimb.y;
			}
			else if (faceDirection == 0) {
				velocity.x = -wallDirX * wallJumpClimb.x;
				velocity.y = wallJumpOff.y;
			}
			else {
				velocity.x = -wallDirX * wallLeap.x;
				velocity.y = wallLeap.y;
			}
		}
        if (playerStatus.isCollidingBottom)
        {
            Jump();

        }

    }
    public void Jump()
    {
        velocity.y = jumpSpeed;
		Debug.Log (velocity.y);

    }


    private void DashIfPossible()
    {
        if (!isDashing && playerStatus.isCollidingBottom)
        {
            Dash();
        }
    }
    public void Dash()
    {		
        velocity.x = faceDirection * movementSpeed * dashMultiplier;
		velocity.y += transform.localPosition.y;
        isDashing = true;
        StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {	
		
		yield return new WaitForSeconds(dashTime);
		isDashing = false;

	}

    private void Move(float direction)
    {
        if (!isDashing)
        {
            if (direction != 0)
            {
                faceDirection = (int)Mathf.Sign(direction);
            }

            velocity.x = direction * movementSpeed;
        }
    }
}
