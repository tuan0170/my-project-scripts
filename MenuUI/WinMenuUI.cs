using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuUI : MenuUI
{
    [SerializeField] private int nextLevel = 1;

    [Header("Link")]
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject butUI;
    [SerializeField] private ItemCollector itemCollector;
    [SerializeField] private TimerCountdown timerCountdown;


    [Header("Reward")]
    [SerializeField] private RewardManager rewardManager;
    [SerializeField] private Text pointText;

    private void Awake()
    {
        winUI.SetActive(false);
        timerCountdown = GetComponent<TimerCountdown>();


    }

    
    private void Update()
    {
        WinMenu();
    }

#region method

private void WinMenu()
    {
         if(itemCollector.Food == itemCollector.FoodTotal)
         {
            Time.timeScale = 0;
            winUI.SetActive(true);
            PointTotal();
         }

         if(timerCountdown.SecondsRight == 0)
         {
            Time.timeScale = 0;
            winUI.SetActive(true);
            pointText.text = "Game Over";
            butUI.SetActive(false);
         }

    }
    private void PointTotal()
    {
        rewardManager.Point = rewardManager.Coin + 7 * timerCountdown.SecondsRight;
        pointText.text = "Points: "+ rewardManager.Point;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if((currentLevel + 1)>PlayerPrefs.GetInt("levelReached"))
        {
            PlayerPrefs.SetInt("levelReached", currentLevel + 1);
        }
         
        // if(rewardManager.Point >PlayerPrefs.GetFloat("LevelPoint") )
        // {
        //     PlayerPrefs.SetFloat("LevelPoint",rewardManager.Point);
        // }
    
        // int currentCoin = PlayerPrefs.GetInt("Coin",rewardManager.TotalCoin);
        

        // PlayerPrefs.SetInt("Coin",currentCoin+rewardManager.Coin);
        // Debug.Log(PlayerPrefs.GetInt("Coin",currentCoin+ rewardManager.Coin));

    }
#endregion
#region event
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + nextLevel);
    }
#endregion


    

}
