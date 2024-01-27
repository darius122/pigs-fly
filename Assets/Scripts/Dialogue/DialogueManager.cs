using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator dialogueAnim;
    int aa;
    Dialogue[] dialogueVal;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue[] dialogue)
    {
        dialogueVal = dialogue;
        dialogueAnim.SetBool("IsOpen", true);


        //Debug.Log(i);
        nameText.text = dialogue[aa].name;
        sentences.Clear();

        foreach (string sentence in dialogue[aa].sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();





    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            aa ++;
            if (NextPerson())
            {
                return;
            }
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    bool NextPerson()
    {
        if (aa >= dialogueVal.Length -1)
        {
            EndDialogue();
            return true;
        }

        nameText.text = dialogueVal[aa].name;
        sentences.Clear();

        foreach (string sentence in dialogueVal[aa].sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        return false;
    }

    void EndDialogue()
    {
         dialogueAnim.SetBool("IsOpen", false);
         aa++;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }


}
