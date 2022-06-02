using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    [SerializeField]private GameObject ShopButton;
    [SerializeField]private ShopManager shopManager;
    private void Awake() 
    {
        ShopButton.SetActive(false);
    }
    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.CompareTag("Player"))
        {
            ShopButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collider) 
    {
        if(collider.CompareTag("Player"))
        {
            ShopButton.SetActive(false);
        }
    }


}
