using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsDebuffPlayer : MonoBehaviour
{
    [SerializeField]private PlayerMovement player;
    
    [SerializeField]private int timePlayerSpeedsDown = 5;

    [SerializeField]private float lowestSpeed = 1.5f;

    [SerializeField]private float playerSpeedsDown = 0.5f;
    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    


    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(player.M_moveSpeed >= lowestSpeed)
            {
                StartCoroutine(PlayerSpeedDown());
            }
        }
    }
    IEnumerator PlayerSpeedDown()
    {
        player.SpeedDown(playerSpeedsDown);
        yield return new WaitForSeconds(timePlayerSpeedsDown);
        player.ReturnCurrentSpeed(playerSpeedsDown);
    }
}
