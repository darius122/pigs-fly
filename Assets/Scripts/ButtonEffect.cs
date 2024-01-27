using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonEffect : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
{
	RectTransform buttonRect;
	ButtonEffect btn;
	private void Start()
	{
		buttonRect = gameObject.GetComponent<RectTransform>();
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		buttonRect.localScale = new Vector3(buttonRect.localScale.x + 0.1f, buttonRect.localScale.y + 0.1f,1);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		buttonRect.localScale = new Vector3(buttonRect.localScale.x - 0.1f, buttonRect.localScale.y - 0.1f, 1);
	}

}
