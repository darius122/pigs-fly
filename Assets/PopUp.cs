using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
     
                transform.localScale = new Vector3(249f, 100, 100f);
    }
    private void OnDisable()
    {
        transform.localScale = Vector3.zero;
    }

    public void Close()
    {
        StartCoroutine(d());
    }

    IEnumerator d()
    {
        yield return new WaitForSeconds(2);
        transform.DOScale(new Vector3(0, 0, 0), 0.4f).OnComplete(() => {
            transform.gameObject.SetActive(false);
          
        });

    }


}
