using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(PlayerController))]
public class Skill_AirbornDash : MonoBehaviour {

	private InputController inputController;
	private PlayerController playerController;
	private void Awake(){
		inputController = GetComponent<InputController> ();
		playerController = GetComponent<PlayerController> ();

		inputController.OnDashPressed += AirbornDash;
	}

	private void OnDestroy(){
		inputController.OnDashPressed -= AirbornDash;
	}

	private void AirbornDash(){
		if (!playerController.playerStatus.isCollidingBottom && playerController.airborneSkillAvailable ) 
		{
			playerController.Dash ();
			playerController.ActivateAirborneSkill ();
		}
	}
}
