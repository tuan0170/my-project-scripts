using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField]private bool unlocked;
    [SerializeField]private Image lockImage;

    private void Update() 
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }
    #region method
    private void UpdateLevelStatus()//if name of previous level <= level reached then unlock this level
    {
        int previousLevelNum = int.Parse(gameObject.name);
        if(previousLevelNum <= PlayerPrefs.GetInt("levelReached"))
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if(!unlocked)//MARKER if unclock is false means This level is clocked!
        {
            lockImage.gameObject.SetActive(true);
        }
        else//if unlock is true means This level can play !
        {
            lockImage.gameObject.SetActive(false);
        }
    }
    #endregion
    #region event
    public void PressSelection(string _LevelName)//When we press this level, we can move to the corresponding Scene to play
    {
        if(unlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }
    #endregion
    #region properties
        public bool Unlocked
        {
            get{return unlocked;}
        }
    #endregion
}
