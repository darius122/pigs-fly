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
    public static cameraManegement ins;

    [SerializeField] GameObject bg, bgparent;
    private void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        RescaleBackGround();
        currentOrthSize = a.m_Lens.OrthographicSize;
        StartCoroutine(Resize());

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(pig.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position) ;
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition2.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition2.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 dis = (WorldObject_ScreenPosition2 - WorldObject_ScreenPosition);
        disTance = dis.magnitude;
        Debug.Log((ViewportPosition.y * RT.sizeDelta.y) + ":" + (ViewportPosition.y * RT.sizeDelta.y));
    }



    public void MoveIndicator()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(pig.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

        Debug.Log(UI_Element.anchoredPosition);
    }

    void MovePlaceMentMarker()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(pig.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position);
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition2.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition2.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));
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

            RescaleBackGround();

            if (currentOrthSize >=10)
            {
                MovePlaceMentMarker();
                UI_Element.gameObject.SetActive(true);
            }
            PB.reCalculateBounds();
        });
    }

    private void RescaleBackGround()
    {
        float height = 2f * this.a.m_Lens.OrthographicSize;
        float width = height * Camera.main.aspect;

        Vector3 newScale = new Vector3(width / 10f, 1f, height / 10f); // Dividing by 10 because the default Unity plane is 10x10 units
        bg.transform.localScale = newScale * 1.5f;
        bgparent.transform.position = transform.position + new Vector3(0, 0, -Camera.main.transform.position.z);


    }
}
