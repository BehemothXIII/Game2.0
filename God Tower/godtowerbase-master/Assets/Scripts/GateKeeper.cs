using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GateKeeper : MonoBehaviour {

	public Text levelText;
	public InputField passwordInput;
	public Text accessDeniedText;

	public string levelNumber;
	public string password;
	public string nextScene;


	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad % 2 < 1) {
			levelText.text = "LEVEL";
		} 
		else {
			levelText.text = levelNumber;
		}
		if(Input.GetKeyDown(KeyCode.Return)){
			CheckPassword();
		}
	}

	public void CheckPassword(){
		if (string.IsNullOrEmpty(passwordInput.text.Trim())) {
			return;
		}
		if (passwordInput.text.Trim () == password) {
			TKSceneManager.ChangeScene (nextScene);
		} else {
			passwordInput.text = "";
			accessDeniedText.gameObject.SetActive (true);
		}
	}
}
