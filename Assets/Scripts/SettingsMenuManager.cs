using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private RectTransform settingsMenuRect;
    [SerializeField] private float rightPosX, middlePosX;
    [SerializeField] private float tweenDuration;
    [SerializeField] private CanvasGroup fadeCG;
    bool isOpen;
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
}
