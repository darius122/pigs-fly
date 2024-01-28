using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.DOScale(new Vector3(249f,100,100f),0.4f).OnComplete(() => {
        }); 
    }
    private void OnDisable()
    {
    }

    public void Close()
    {
        transform.DOScale(new Vector3(0, 0, 0), 0.4f).OnComplete(() => {

            transform.gameObject.SetActive(false);
        });

    }

}
