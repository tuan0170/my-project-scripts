using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField]private float speed = 2f;
    [SerializeField]private PauseMenuUI pauseMenuUI;
    [SerializeField]private DialogueManager dialogueManager;
    [SerializeField]private ShopManager shopManager;

    // Update is called once per frame
    void Update()
    {
        if(!pauseMenuUI.Pause && !dialogueManager.DialogueIsActive && !shopManager.IsShopping)
        {
            movingPlatform();
        }   
    }
    #region method
    private void movingPlatform() //flatform move by waypoints
    {
        if(Vector3.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex>= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    #endregion
    
}
