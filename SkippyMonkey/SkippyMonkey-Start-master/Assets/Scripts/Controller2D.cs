using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour {

	private Bounds colliderBounds;
	private BoxCollider2D bc2D;
	private RaycastOrigins raycastOrigins;

	private float skinWidth = 0.015f;
	public LayerMask collideMask;
	public int NoOfRay;
	float distanceBetweenRayHorizontal;
	float distanceBetweenRayVertical;
	public CollisionInfo collision;
	private void Awake (){
		bc2D = GetComponent<BoxCollider2D> ();

	}
	public void Move(Vector2 velocity){
		UpdateColliderBounds ();
		CalculateRaySpacing ();
		collision.Reset ();
		velocity = RaycastHorizontal (velocity);
		velocity = RaycastVertical (velocity);


		transform.Translate(velocity);
	}

	private Vector2 RaycastHorizontal(Vector2 velocity){
		float directionX = Mathf.Sign(velocity.x);
		float rayLength = Mathf.Abs (velocity.x) + skinWidth;
		for (int i = 0; i < NoOfRay; i++) {
			Vector2 raycastOrigin = (directionX == -1 ) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
			raycastOrigin += Vector2.up * (distanceBetweenRayHorizontal * i);
			RaycastHit2D hit = Physics2D.Raycast (raycastOrigin, velocity.WithY(0), rayLength, collideMask);
			Debug.DrawRay (raycastOrigin, velocity.WithY(0) * rayLength, Color.green);
			if (hit) {
				velocity.x = (hit.distance - skinWidth) * directionX;
				rayLength = hit.distance;
				collision.collideLeft = directionX == -1;
				collision.collideRight = directionX == 1;
				Debug.Log (hit + "Horizontal hit");
			}

		}
		return velocity;

	}

	private Vector2 RaycastVertical(Vector2 velocity){
		
		float directionY = Mathf.Sign(velocity.y);
		float rayLength = Mathf.Abs (velocity.y) + skinWidth;
		for (int i = 0; i < NoOfRay; i++) {
			Vector2 raycastOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
			raycastOrigin += Vector2.right * (distanceBetweenRayVertical * i + velocity.x);
			RaycastHit2D hit = Physics2D.Raycast (raycastOrigin, velocity.WithX(0), rayLength, collideMask);
			Debug.DrawRay (raycastOrigin, velocity.WithX(0) * rayLength, Color.green);
			if (hit) {
				velocity.y = (hit.distance - skinWidth )* directionY;
				rayLength = hit.distance;

				collision.collideBottom = directionY == -1;
				collision.collideTop = directionY == 1;
				Debug.Log (hit + "Vertical hit");
			}

		}
		return velocity;
	}

	private void UpdateColliderBounds(){
		colliderBounds = bc2D.bounds;
		colliderBounds.Expand(skinWidth * -2); //Co lai collider bound 0.01f 
		UpdateRaycastOrigins ();
	}

	private void UpdateRaycastOrigins(){
		raycastOrigins.topLeft = new Vector2 (colliderBounds.min.x, colliderBounds.max.y);
		raycastOrigins.topRight = new Vector2 (colliderBounds.max.x, colliderBounds.max.y);
		raycastOrigins.bottomLeft = new Vector2 (colliderBounds.min.x, colliderBounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (colliderBounds.max.x, colliderBounds.min.y);
	}

	private void CalculateRaySpacing(){
		colliderBounds = bc2D.bounds;
		colliderBounds.Expand(skinWidth * -2);
		NoOfRay = Mathf.Clamp (NoOfRay, 2, int.MaxValue);
		distanceBetweenRayHorizontal = colliderBounds.size.y / (NoOfRay - 1);
		distanceBetweenRayVertical = colliderBounds.size.x / (NoOfRay - 1);
	}
}

struct RaycastOrigins{
	public Vector2 topLeft;
	public Vector2 topRight;
	public Vector2 bottomLeft;
	public Vector2 bottomRight;
}

public struct CollisionInfo{
	public bool collideTop, collideBottom;
	public bool collideLeft, collideRight;

	public void Reset(){
		collideTop = collideBottom = false;
		collideLeft = collideRight = false;
	}

}

