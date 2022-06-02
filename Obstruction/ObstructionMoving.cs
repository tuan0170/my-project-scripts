using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionMoving : MonoBehaviour
{
    [SerializeField]private PlayerLife player;
    //[SerializeField]private ga
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.rb.AddForce(player.transform.position.x, player.transform.position.y, player.transform.position.z * - 100f);
        }
    }
}
