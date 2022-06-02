using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioSource collectSound;

    [SerializeField] private int foods;
    [SerializeField] private int foodTotal = 7;
    

    [Header("Buff and Debuff")]
    [SerializeField]private float speedUp = 0.2f;
    
    [Header("Link")]
    private PlayerMovement player;
    [SerializeField]private TimerCountdown timerCountdown;
    [SerializeField]private PauseMenuUI pauseMenuUI;
    [SerializeField]private DialogueManager dialogueManager;

    [SerializeField]private RewardManager rewardManager;

    [SerializeField]private int timeUp = 10;
    private bool takeAway = false;

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //timerCountdown = GetComponent<TimerCountdown>();
    }

    
    #region event
    public void OnTriggerEnter(Collider col) //check and perform trigger with coin
    {
        if(col.CompareTag("Coin"))
        {
            rewardManager.Coin++;
            collectSound.Play();
            Destroy(col.gameObject);
            
        }
        else if(col.CompareTag("Food"))//check and perform trigger with food
        {
            foods++;
            player.M_moveSpeed += speedUp;
            collectSound.Play();
            timerCountdown.SecondsRight += timeUp;
            Destroy(col.gameObject);
        }
    }
    #endregion
    #region properties
     public int Food
     {
         get{ return foods;}
         set{foods = value;}
     }

     public int FoodTotal
     {
         get{ return foodTotal;}
         set{foodTotal = value;}
     }
#endregion

}
