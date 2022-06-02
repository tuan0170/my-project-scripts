using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFlatform : MonoBehaviour
{
    //[SerializeField] private GameObject player;

    #region event
    private void OnCollisionEnter(Collision col) {//set player is child of flatform
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision col) {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(null);
        }
    }
    #endregion
    

}
