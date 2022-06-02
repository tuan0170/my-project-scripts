using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    [SerializeField]private GameObject enemy3DTextName;
    [SerializeField]private PlayerMovement player;


    [Header("Parameter")]
    [SerializeField]private float playerSpeedsDown = 0.5f;
    [SerializeField]private int timePlayerSpeedsDown = 5;

    [SerializeField]private float lowestSpeed = 1.5f;

    private void Update() 
    {
        this.transform.position = enemy.transform.position;
        UpdatePositionName();
    }

    private void UpdatePositionName()
    {
        enemy3DTextName.transform.position = enemy.transform.position;
    }
    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.CompareTag("Player"))
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
