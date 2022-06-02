using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField]private GameObject textDisplay;
    [SerializeField]private int secondsRight = 30;
    [SerializeField]private bool takingAway = false;
    [SerializeField]private PauseMenuUI pauseMenuUI;
    [SerializeField]private ShopManager shopManager;
    [SerializeField]private DialogueManager dialogueManager;

    private void Start() 
    {
        textDisplay.GetComponent<Text>().text = "Thời gian: "+secondsRight;
    }
    private void Update() 
    {
        if(!takingAway && secondsRight >=0 && !pauseMenuUI.Pause
         && !dialogueManager.DialogueIsActive && !shopManager.IsShopping)
        {
            StartCoroutine(TimerTake());
        }
    }

    #region method
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new  WaitForSeconds(1);
        secondsRight -= 1;
        textDisplay.GetComponent<Text>().text = "Thời gian: "+secondsRight;
        takingAway = false;
    }
    #endregion
    #region properties
    public int SecondsRight
    {
        get{ return secondsRight;}
        set{ secondsRight = value;}
    }

    #endregion
    
}
