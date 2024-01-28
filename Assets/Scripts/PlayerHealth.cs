using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject dieScreen;
    public int health = 2;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            health--;
            Destroy(collision.gameObject);

            if (health == 0)
            {
                StopAllCoroutines();
                StartCoroutine(DieScreen());
            }
        }
    }
  
    IEnumerator DieScreen()
    {
        yield return new WaitForSeconds(2f);
        dieScreen.SetActive(true);

    }
}
