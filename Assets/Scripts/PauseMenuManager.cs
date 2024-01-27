using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenuManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI countdownText;
	[SerializeField] private GameObject pauseMenu;

	bool isOpen;
	bool isPPressedOnce;
	int countdownTimer = 2;

	private void Start()
	{
	}
	// Update is called once per frame
	void Update()
    {

		if (Input.GetKeyDown(KeyCode.P) && !isPPressedOnce)
		{
			if (!isOpen)
			{
				pauseMenu.SetActive(true);
				isOpen = true;
			}
			else
			{
				OnBackButton();
			}
		}

		if (pauseMenu.activeInHierarchy || isPPressedOnce)
		{
			Time.timeScale = 0.0f;
		}
	
    }

	public IEnumerator StartCountdown(float waitSecs)
	{
		
		yield return new WaitForSecondsRealtime(waitSecs);
		countdownText.text = (countdownTimer).ToString();
		countdownTimer -= 1;
		if (countdownTimer != -1)
		{
			StartCoroutine(StartCountdown(1.5f));
		}
		else
		{
			countdownTimer = 2;
			countdownText.text = "FLY BABI";
			yield return new WaitForSecondsRealtime(waitSecs);
			isPPressedOnce = false;
			countdownText.text = "";
			Time.timeScale = 1.0f;
		}

	}

	public void OnBackButton()
	{
		pauseMenu.SetActive(false);
		isOpen = false;
		if (!isPPressedOnce)
		{
			countdownText.text = (countdownTimer + 1).ToString();
			StartCoroutine(StartCountdown(1.5f));
		}
		isPPressedOnce = true;
	}
}
