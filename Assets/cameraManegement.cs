using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class cameraManegement : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera a;
    int b = 0;
    [SerializeField] float currentOrthSize;
    // Start is called before the first frame update
    void Start()
    {
        currentOrthSize = a.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            ExpanView(5);
        }
    }
    void ExpanView(float a)
    {
        DOTween.To(() => currentOrthSize, x => currentOrthSize = x, currentOrthSize+a, 1f).OnUpdate(() => {

            this.a.m_Lens.OrthographicSize = currentOrthSize;
        });
    }
}
