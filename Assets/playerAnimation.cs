using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class playerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PopUp ExpressionGameObjecttop, ExpressionGameObjectBottom;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CloseExpression()
    {
        ExpressionGameObjecttop.Close();
        ExpressionGameObjectBottom.Close();
    }

    public void SetTrigger(string animationName)
    {
        anim.SetTrigger(animationName);
        ExpressionGameObjecttop.gameObject.SetActive(true);
        ExpressionGameObjectBottom.gameObject.SetActive(true);
    }

}
