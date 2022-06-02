using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEnterTrigger : MonoBehaviour
{
    [SerializeField]private GameObject readButton; // used to read dialogues

    private void Start() 
    {
        readButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            readButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            readButton.SetActive(false);
        }
    }
}
