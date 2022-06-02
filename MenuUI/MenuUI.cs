using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField]  protected int m_levelLoad;
   

    #region event
    public void PlayButton()
    {
        SceneManager.LoadScene(m_levelLoad);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackMainMenuButton()
    {
        SceneManager.LoadScene("StartScene");    
    }

    #endregion

}
