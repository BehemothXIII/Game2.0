using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;


public class Skill_SlowTime : MonoBehaviour {

	private bool isSlow;
	private Clock clock;

	private void Awake()
	{
		clock = Timekeeper.instance.Clock("Enemies");
	}


	// Use this for initialization
	void Start () {
		isSlow = false;

	}

	void Update(){
		if(!isSlow && Input.GetKeyDown(KeyCode.T)){
			isSlow = true;
			StartCoroutine(Slow());
		}

	}


	IEnumerator Slow(){
		clock.localTimeScale = 0.5f;
		yield return new WaitForSeconds (2f);
		clock.localTimeScale = 1f;
		isSlow = false;
	}


}
