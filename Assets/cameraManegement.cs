using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class cameraManegement : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera a;
    [SerializeField]PlayerBoundaries PB;
    [SerializeField] float currentOrthSize;
    // Start is called before the first frame update
    void Start()
    {
        currentOrthSize = a.m_Lens.OrthographicSize;

        StartCoroutine(Resize());
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
            PB.reCalculateBounds();
        });
    }
}
