using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField]private GameObject[] destinations; // 
    [SerializeField]private int currentDestinationIndex;

    [SerializeField]private Animator enemyAnimator;


    [Header("Enemy Properties")]
    [SerializeField]private float enemySpeed;
    [SerializeField]private float enemySpeedAfterRest;
    [SerializeField]private float restTime;
    [SerializeField]private bool isWalking;
    private void Awake() 
    {
        isWalking = true;
    }
    private void Update() 
    {
        EnemyMove();
    }

    #region method
    private void EnemyMove()
    {
        var nextDestination = destinations[currentDestinationIndex].transform.position;
        if(Vector3.Distance(nextDestination, transform.position) < .1f)
        {
            StartCoroutine(IsRest());
            EnemyDirection();
            currentDestinationIndex++;
            if(currentDestinationIndex>= destinations.Length)
            {
                currentDestinationIndex = 0;
            }
            
        }
        IsWalk();
        transform.position = Vector3.MoveTowards(transform.position, 
                        nextDestination, Time.deltaTime * enemySpeed);
    }

    IEnumerator IsRest()
    {
        isWalking = false;
        enemySpeed = 0;
        enemyAnimator.SetBool("IsWalking", false);
        yield return new WaitForSeconds(restTime);
        enemySpeed = enemySpeedAfterRest;
        isWalking = true;
    }

    private void IsWalk()
    {
        if(isWalking)
        {
            enemyAnimator.SetBool("IsWalking", true);
        }
        if(!isWalking)
        {
            enemyAnimator.SetBool("IsWalking", false);
        }
    }

    private void EnemyDirection() //temporary method
    {
        if(currentDestinationIndex == 1)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if(currentDestinationIndex == 0)
        {
            transform.localScale = new Vector3(1,1,-1);
        }
    }
    #endregion

}
