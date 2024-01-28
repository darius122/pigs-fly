using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DieScreen : MonoBehaviour
{
    public TextMeshProUGUI dieText;
    public TextMeshProUGUI otherText;

    public Color fadeincolor;
    public Color fadeoutcolor;
    public float fadeSpeed = 0.1f; 

    float timer = 2f;
    float timer2 = 4f;
    bool dieTextFadeOut = false;

    public Button mainmenuBtn;

    private void Start()
    {
        mainmenuBtn.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (dieTextFadeOut)
        {
            FadeOut(dieText);
            FadeIn(otherText);
        }
        else
        {
            FadeIn(dieText);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            dieTextFadeOut = true;
            //timer = 2f;

            if(timer2 > 0)
            {
                timer2 -= Time.deltaTime;
            }
            if(timer2 <= 0)
            {
                mainmenuBtn.gameObject.SetActive(true);
            }
        }     
    }

    void FadeOut(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.color = Color.Lerp(textMeshProUGUI.color, fadeoutcolor, fadeSpeed * Time.deltaTime * 3);
    }
    void FadeIn(TextMeshProUGUI textMeshProUGUI)
    {
        textMeshProUGUI.color = Color.Lerp(textMeshProUGUI.color, fadeincolor, fadeSpeed * Time.deltaTime);

    }

    public void OnClickMainMenu()
    {
        //back to main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);


    }
}
