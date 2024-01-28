using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] public Animator[] animator;
	[SerializeField] private CanvasGroup blackPanel;
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
		SettingsMenuManager.instance.PlayMusic("MainMenu");
	}
	public void OnPlay()
	{
		blackPanel.DOFade(1, 2f).OnComplete(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
		SettingsMenuManager.instance.StopMusic("MainMenu");

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
