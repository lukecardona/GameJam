using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private int count = 3;

    private string sentence;

    // Start is called before the first frame update
    void Start()
    {
        sentence = "Depression affects the body. Headache, stomach problems, headaches, and general aches and pains without a clear physical cause can all be symptoms of depression, according to the NIMH.";
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            EndDialogue();
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
