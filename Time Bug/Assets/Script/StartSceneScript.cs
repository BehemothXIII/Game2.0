using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private void Start()
    {
        if (backgroundMusic.enabled)
        {
            backgroundMusic.Play();
        }
    }


    public void LoadPlayScene()
    {
        TKSceneManager.ChangeScene("Level 1");
    }

	public void Quit(){
		Application.Quit ();
	}
}
