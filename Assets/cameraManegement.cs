using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class cameraManegement : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera a;
    [SerializeField]PlayerBoundaries PB;
    int b = 0;
    [SerializeField] float currentOrthSize;
    // Start is called before the first frame update
    void Start()
    {
        currentOrthSize = a.m_Lens.OrthographicSize;

        StartCoroutine(resize());
    }

    IEnumerator resize()
    {
        yield return new WaitForSeconds(4);
        ExpanView(5);
        StartCoroutine(resize());
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void ExpanView(float a)
    {
        DOTween.To(() => currentOrthSize, x => currentOrthSize = x, currentOrthSize+a, 1f).OnUpdate(() => {

            this.a.m_Lens.OrthographicSize = currentOrthSize;
            PB.reCalculateBounds();
        });
    }
}
