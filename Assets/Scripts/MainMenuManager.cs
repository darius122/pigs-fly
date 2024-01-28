using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] public Animator[] animator;
	float offsetTimer;
	private void Update()
	{
		offsetTimer += Time.deltaTime;
		if (offsetTimer >= 4)
		{
			animator[0].SetTrigger("triggerShocked");
			animator[1].SetTrigger("triggerWeary");
			animator[2].SetTrigger("triggerBruh");
			offsetTimer = 0;
		}
	}
	private void Start()
	{
	}
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
