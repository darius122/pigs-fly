using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class SettingsMenuManager : MonoBehaviour
{
	public Sound[] musicSounds, sfxSounds;
	public AudioSource musicSource, sfxSource;
	[SerializeField] private GameObject settingsMenu;
    [SerializeField] private RectTransform settingsMenuRect;
    [SerializeField] private float rightPosX, middlePosX;
    [SerializeField] private float tweenDuration;
    [SerializeField] private CanvasGroup fadeCG;
    [SerializeField] private Slider sliderMusic , sliderSFX;
    [SerializeField] private TextMeshProUGUI musicText, sfxText;
    public static SettingsMenuManager instance;
    bool isOpen;

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
	private void Update()
	{
        MusicVolume(sliderMusic.value);
        SFXVolume(sliderSFX.value);
        musicText.text = Mathf.RoundToInt((sliderMusic.value * 100)).ToString();
        sfxText.text = Mathf.RoundToInt((sliderSFX.value * 100)).ToString();

    }
    public void OnSettingsButton()
	{
        if (!isOpen)
        {
            SettingsMenuIntro();
            settingsMenu.SetActive(true);
            isOpen = true;
        }
        else
		{
            SettingsMenuOutro();
            isOpen = false;
		}
	}
    public void SettingsMenuIntro()
	{
        fadeCG.DOFade(1, tweenDuration).SetUpdate(true);
        settingsMenuRect.DOAnchorPosX(middlePosX, tweenDuration).SetUpdate(true);
    }

    public void SettingsMenuOutro()
	{
        fadeCG.DOFade(0, tweenDuration).SetUpdate(true);
        settingsMenuRect.DOAnchorPosX(rightPosX, tweenDuration).SetUpdate(true).OnComplete(() => settingsMenu.SetActive(false));
    }


	public void PlayMusic(string name)
	{
		Sound s = Array.Find(musicSounds, result => result.name == name);

		if (s == null)
		{
			Debug.Log("Sound not found");
		}
		else
		{
			musicSource.clip = s.clip;
			musicSource.Play();
		}
	}

	public void PlaySFX(string name)
	{
		Sound s = Array.Find(sfxSounds, result => result.name == name);

		if (s == null)
		{
			Debug.Log("Sound not found");
		}
		else
		{
			sfxSource.clip = s.clip;
			sfxSource.Play();
		}
	}

	public void ToggleMusic()
	{
		musicSource.mute = !musicSource.mute;
	}

	public void ToggleSFX()
	{
		sfxSource.mute = !sfxSource.mute;
	}

	public void MusicVolume(float volume)
	{
		musicSource.volume = volume;
	}
	public void SFXVolume(float volume)
	{
		sfxSource.volume = volume;
	}

}
