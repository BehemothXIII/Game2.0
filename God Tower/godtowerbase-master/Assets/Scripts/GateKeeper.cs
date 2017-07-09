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

	public List<GameObject> hints;
	public Button nextHintButton;
	private int currHintIndex = 0;

	private void Start(){
		if (hints.Count > 1) {
			nextHintButton.gameObject.SetActive (true);
		}
	}


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

	public void OnHintButtonClick(){
		currHintIndex = (currHintIndex + 1) % hints.Count; // currHintIndex +=1; if(currHintIndex >=hints.Count){currHintIndex = 0);
		if (currHintIndex == hints.Count - 1) {
			nextHintButton.transform.localScale = new Vector3 (-1, 1, 0);
		}
		for(int i = 0; i<hints.Count; i++)
		{
			hints[i].SetActive(i == currHintIndex);
		}
	}
}
