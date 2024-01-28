using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
	public static PauseMenuManager instance;
	[SerializeField] private TextMeshProUGUI countdownText;
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private RectTransform pauseMenuRect;
	[SerializeField] private float leftPosX, middlePosX;
	[SerializeField] private float tweenDuration;
	[SerializeField] private CanvasGroup fadeCG;

	bool isOpen;
	bool isPPressedOnce;
	int countdownTimer = 2;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	void Update()
    {

		if ((Input.GetKeyDown(KeyCode.P) && !isPPressedOnce) && SceneManager.GetActiveScene().buildIndex != 0)
		{
			if (!isOpen)
			{
				pauseMenu.SetActive(true);
				isOpen = true;
				PausePanelIntro();
				Time.timeScale = 0.0f;

			}
			else
			{
				OnBackButton();
			}
			if (pauseMenu.activeSelf)
			{
				Time.timeScale = 0.0f;
			}
		}
    }

	public IEnumerator StartCountdown(float waitSecs)
	{
		
		yield return new WaitForSecondsRealtime(waitSecs);
		countdownText.text = (countdownTimer).ToString();
		countdownTimer -= 1;
		if (countdownTimer != -1)
		{
			StartCoroutine(StartCountdown(1.0f));
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
		PausePanelOutro();

		isOpen = false;
		if (!isPPressedOnce)
		{
			countdownText.text = (countdownTimer + 1).ToString();
			StartCoroutine(StartCountdown(1.0f));
		}
		isPPressedOnce = true;
	}

	public void PausePanelIntro()
	{
		fadeCG.DOFade(1, tweenDuration).SetUpdate(UpdateType.Late,true);
		pauseMenuRect.DOAnchorPosX(middlePosX, tweenDuration).SetUpdate(UpdateType.Late, true);
	}

	public void PausePanelOutro()
	{
		fadeCG.DOFade(0, tweenDuration).SetUpdate(UpdateType.Late, true);
		pauseMenuRect.DOAnchorPosX(leftPosX, tweenDuration).SetUpdate(UpdateType.Late, true).OnComplete(() => pauseMenu.SetActive(false));
	}

	public void OnButtonMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
