using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionUI : MenuUI
{
    [SerializeField] private bool pause = false;
    [SerializeField] private GameObject optionUI;

    #region properties
    public bool Pause
    {
        get{return pause;}
    }
    #endregion
    private void Start() 
    {
        optionUI.SetActive(false);
    }

    private void Update() 
    {
        OptionMenu();
    }
    #region method

    private void OptionMenu()//menu will open when pause = true
    {
        if(pause)
        {
            optionUI.SetActive(true);
        }

        if(!pause)
        {
            optionUI.SetActive(false);
        }
    }
    #endregion
    #region Event
    public void BackButton()
    {
        pause = false;
    }

    public void OptionButton()
    {
        pause = true;
    }

    #endregion

}
