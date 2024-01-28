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
            StartCoroutine(Close());
        }); 
    }
    private void OnDisable()
    {
    }

    IEnumerator  Close()
    {
        yield return new WaitForSeconds(1);

        transform.DOScale(new Vector3(0, 0, 0), 0.4f).OnComplete(() => {

            transform.gameObject.SetActive(false);
        });

    }

}
