using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject dieScreen;
    private int health = 2;
    public List<Image> heartSprites = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        populateHealthSprites(health);
    }
    private void populateHealthSprites(int currHealth)
    {
        foreach(Image image in heartSprites)
        {
            image.gameObject.SetActive(false);
        }
        for(int i = 0; i < currHealth; i++)
        {
            heartSprites[i].gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            health--;
            populateHealthSprites(health);
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
