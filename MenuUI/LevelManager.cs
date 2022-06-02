using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField]private Button[] levelButton;
    private void Start() 
    {
        //esetLevel();
        UnlockNextLevel();
    }
    #region method
    //open next level when finished a level
    private void UnlockNextLevel()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = 0; i <levelButton.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButton[i].interactable = false;
            }
        }
    }

    private void ResetLevel()
    {
        PlayerPrefs.SetInt("levelReached", 1);
    }

    
    #endregion
}
