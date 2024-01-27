using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public void OnPlay()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void OnSettings()
	{
		// Load Settings Scene
	}
	public void OnExit()
	{
		Application.Quit();
	}

}
