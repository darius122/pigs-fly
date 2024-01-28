using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
{
	RectTransform buttonRect;
	Button btn;

	private void Start()
	{
		buttonRect = gameObject.GetComponent<RectTransform>();
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(Select);
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		buttonRect.localScale = new Vector3(buttonRect.localScale.x + 0.1f, buttonRect.localScale.y + 0.1f,1);
		SettingsMenuManager.instance.PlaySFX("Hover");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		buttonRect.localScale = new Vector3(buttonRect.localScale.x - 0.1f, buttonRect.localScale.y - 0.1f, 1);
	}
	void Select()
	{
		SettingsMenuManager.instance.PlaySFX("Select");
	}

}
