using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]private Dialogue dialogue;
    [SerializeField]private DialogueManager dialogueManager;
    [SerializeField]private PlayerLife playerLife;

    public void TriggerDialogue()
    {
        dialogueManager.Sentences = new Queue<string>();
        dialogueManager.StartDialogue(dialogue);
    }
}
