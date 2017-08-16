using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class Guard : MonoBehaviour {
    public float posY;
    public RangeGuard rangeX;
    public float moveSpeed;

    public bool isAlerted = false;
    public float timeCoolDown = 0.2f;

    private DirectionFace direction = DirectionFace.Left;
	private Timeline myTimeLine;
	private Player player;
	private Animator anim;
    // Use this for initialization
    void Start()
    {
		myTimeLine = GetComponent<Timeline> ();
		player = FindObjectOfType<Player> ().GetComponent<Player> ();
		anim = GetComponent<Animator> ();
		anim.Play ("Robot Move");
    }


    private void Patrol()
    {
		if (myTimeLine.timeScale > 0) {
			transform.position += new Vector3 (moveSpeed * ((direction == DirectionFace.Right) ? 1 : -1) * myTimeLine.fixedDeltaTime, 0, 0);
			if ((transform.position.x < rangeX.MinPosRange) && (direction == DirectionFace.Left)) {
				direction = DirectionFace.Right;
//				
			}
			if ((transform.position.x > rangeX.MaxPosRange) && (direction == DirectionFace.Right)) {
				direction = DirectionFace.Left;
//				
			}
		}

    }

    private void Shoot()
    {
        if (isAlerted) StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
    yield return new WaitForSeconds(timeCoolDown);

    }
	// Update is called once per frame
	void FixedUpdate () {
        Patrol();
    }

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			
			player.Die ();
		} else {
			
		}
	}
}

public enum DirectionFace
{
    Left,
    Right
}

[System.Serializable]
public struct RangeGuard
{
    public float MinPosRange;
    public float MaxPosRange;
}
