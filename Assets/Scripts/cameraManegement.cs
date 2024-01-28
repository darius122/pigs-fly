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
    [SerializeField] RectTransform FlipUI_Element;
    [SerializeField] float currentOrthSize;
    [SerializeField] Transform topSide;
    [SerializeField] Transform bottomSide;
    [SerializeField] Transform pigBody;
    public float level = 0;

    [SerializeField] float TdisTance,Bdistance;
    public static cameraManegement ins;

    [SerializeField] GameObject bg, bgparent;
    [SerializeField] playerAnimation test;

    public GameObject winScreen;
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

     
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.L))
        {
            ExpandView(5); test.SetTrigger();
        }
    }

    public void CalTopDiff()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(topSide.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position);
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition2.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition2.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 dis = (WorldObject_ScreenPosition2 - WorldObject_ScreenPosition);
        TdisTance = dis.magnitude;
        Debug.Log((ViewportPosition.y * RT.sizeDelta.y) + ":" + (ViewportPosition.y * RT.sizeDelta.y));
    }
    public void BotTopDiff()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(bottomSide.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position);
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition2.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition2.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 dis = (WorldObject_ScreenPosition2 - WorldObject_ScreenPosition);
        Bdistance = dis.magnitude;
        Debug.Log((ViewportPosition.y * RT.sizeDelta.y) + ":" + (ViewportPosition.y * RT.sizeDelta.y));
    }
    public void MoveIndicator()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(topSide.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

    }
    public void BotMoveIndicator()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(bottomSide.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        FlipUI_Element.anchoredPosition = WorldObject_ScreenPosition;

    }

    public void flipTrue(bool a)
    {
        if (currentOrthSize <10)
        {
            return;
        }

            FlipUI_Element.gameObject.SetActive(a);

        UI_Element.gameObject.SetActive(!a);
    }

    void MoveTopSidePlaceMentMarker()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(topSide.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position);
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition2.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition2.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));
        if (WorldObject_ScreenPosition.y - WorldObject_ScreenPosition2.y <TdisTance)
        {
            topSide.transform.Translate(Vector2.up);
        }

    }
    void MoveBottomSidePlaceMentMarker()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(bottomSide.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));

        Vector2 ViewportPosition2 = Camera.main.WorldToViewportPoint(pigBody.position);
        Vector2 WorldObject_ScreenPosition2 = new Vector2(
        ((ViewportPosition2.x * RT.sizeDelta.x) - (RT.sizeDelta.x * 0.5f)),
        ((ViewportPosition2.y * RT.sizeDelta.y) - (RT.sizeDelta.y * 0.5f)));
        if (WorldObject_ScreenPosition.y - WorldObject_ScreenPosition2.y < Bdistance)
        {
            bottomSide.transform.Translate(Vector2.up);
        }

    }

    IEnumerator Resize()
    {
        yield return new WaitForSeconds(15);
        ExpandView(5);
        if (level < 6)
        {
            test.SetTrigger();
            StartCoroutine(Resize());

        }
        else
        {
            winScreen.SetActive(true);
        }
    }
    void ExpandView(float a)
    {
        level+=2;
        DOTween.To(() => currentOrthSize, x => currentOrthSize = x, currentOrthSize+a, 1f).OnUpdate(() => {

            this.a.m_Lens.OrthographicSize = currentOrthSize;

            RescaleBackGround();

            if (currentOrthSize >=10)
            {
                MoveTopSidePlaceMentMarker();
                MoveBottomSidePlaceMentMarker();

                PB.CallFlip();
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
