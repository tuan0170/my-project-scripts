using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MenuUI
{
    [SerializeField] private bool pause = false;
    [SerializeField] private GameObject pauseUI;

    #region properties
    public bool Pause
    {
        get{return pause;}
    }
    #endregion
    private void Start() 
    {
        pauseUI.SetActive(false);
    }

    private void Update() 
    {
        PauseMenu();
    }
    #region method

    private void PauseMenu()//menu will open when pause = true
    {
        if(Input.GetKeyDown(KeyCode.Escape))    
        {
            pause = !pause; 
            Time.timeScale = 0; 
        }

        if(pause)
        {
            pauseUI.SetActive(true);
        }

        if(!pause)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    #endregion
    #region Event
    public void RemuseButton()
    {
        pause = false;
    }

    public void MenuButton()
    {
        pause = true;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(m_levelLoad);
        
    }
    #endregion

}
