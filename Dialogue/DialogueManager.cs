using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]private Queue<string> sentences; // sentences will 

    public Text nameText;
    public Text dialogueText;
    [SerializeField]private bool dialogueIsActive;
    [SerializeField]private Animator animator;
    #region properties
    public Queue<string> Sentences
    {
        get{return sentences;}
        set{sentences = value;}
    }

    public bool DialogueIsActive
    {
        get{return dialogueIsActive;}
        set{dialogueIsActive = value;}
    }

    public Animator Animator
    {
        get{return animator;}
        set{animator = value;}
    }
    #endregion

    private void Awake() 
    {
        animator.SetBool("IsOpen", false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        
        animator.SetBool("IsOpen", true);
        dialogueIsActive = true;
        nameText.text = dialogue.Name;
        sentences.Clear();
        foreach(string sentence in dialogue.Sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentences();
    }
    public void DisplayNextSentences()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();  
        dialogueText.text = sentence;
        // StopAllCoroutines();
        // StartCoroutine(TypeSentences(sentence));
        
        
    }
    // IEnumerator TypeSentences (string sentence)
    // {
    //     dialogueText.text = "";
    //     foreach(char letter in sentence.ToCharArray())
    //     {
    //         dialogueText.text += letter;
    //         yield return null;
    //     }
    // }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        dialogueIsActive = false;
    }
}
