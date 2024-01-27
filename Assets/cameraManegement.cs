using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;
public class cameraManegement : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera a;

    [SerializeField]PlayerBoundaries PB;
    [SerializeField] RectTransform RT;
    [SerializeField] RectTransform UI_Element;
    [SerializeField] float currentOrthSize;
    [SerializeField] Transform pig;
    [SerializeField] Transform pigBody;

    [SerializeField] float disTance;
    // Start is called before the first frame update
    void Start()
    {
        currentOrthSize = a.m_Lens.OrthographicSize;
        StartCoroutine(Resize());

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(pig.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position) ;
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 dis = (WorldObject_ScreenPosition2 - WorldObject_ScreenPosition);
        disTance = dis.magnitude;
        Debug.Log(ViewportPosition + ":" + ViewportPosition2);
    }

    private void LateUpdate()
    {
        MovePlaceMentMarker();

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(pig.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        UI_Element.anchoredPosition = WorldObject_ScreenPosition;
    }

    void MovePlaceMentMarker()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(pig.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position);
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));
        Debug.Log(Vector2.Distance(WorldObject_ScreenPosition, WorldObject_ScreenPosition2));
        if (Vector2.Distance(WorldObject_ScreenPosition, WorldObject_ScreenPosition2)<disTance)
        {
            pig.transform.Translate(Vector2.up);
        }

    }

    IEnumerator Resize()
    {
        yield return new WaitForSeconds(4);
        ExpandView(5);
        StartCoroutine(Resize());
    }
    void ExpandView(float a)
    {
        DOTween.To(() => currentOrthSize, x => currentOrthSize = x, currentOrthSize+a, 1f).OnUpdate(() => {

            this.a.m_Lens.OrthographicSize = currentOrthSize;
            if(currentOrthSize >=10)
            {
                UI_Element.gameObject.SetActive(true);
            }
            PB.reCalculateBounds();
        });
    }
}
