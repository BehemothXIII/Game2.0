using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class TimeControl : MonoBehaviour
{
	public bool isSlow = false;
	public bool isPause = false;
	public bool isAccelerate = false;
	public bool isRewind = false;

	public KeyCode slowK;
	public KeyCode accelerateK;
	public KeyCode stopK;
	public KeyCode rewindK;

	private Clock clock;

	void Start(){
		// Get the Enemies global clock
		clock = Timekeeper.instance.Clock("Enemies");

	}
	void Update()
	{
		
		// Change its time scale on key press
		if (Input.GetKeyDown(rewindK))
		{
			isRewind = true;
			StartCoroutine (Rewind ());
		}
		else if (Input.GetKeyDown(stopK))
		{
			isPause = true;
			StartCoroutine (Pause());
		}
		else if (Input.GetKeyDown(slowK))
		{
			isSlow = true;
			StartCoroutine (Slow ());
		}
		else if (Input.GetKeyDown(accelerateK))
		{
			isAccelerate = true;
			StartCoroutine (Accelerate ());
		}
	}

	IEnumerator Slow(){
		clock.localTimeScale = 0.25f;
		yield return new WaitForSeconds (2f);
		clock.localTimeScale = 1f;
		isSlow = false;
	}

	IEnumerator Pause(){
		clock.localTimeScale = 0f;
		yield return new WaitForSeconds (2f);
		clock.localTimeScale = 1f;
		isPause = false;
	}

	IEnumerator Rewind(){
		clock.localTimeScale = -1f;
		yield return new WaitForSeconds (5f);
		clock.localTimeScale = 1f;
		isRewind = false;
	}

	IEnumerator Accelerate(){
		clock.localTimeScale = 2f;
		yield return new WaitForSeconds (2f);
		clock.localTimeScale = 1f;
		isAccelerate = false;
	}
}