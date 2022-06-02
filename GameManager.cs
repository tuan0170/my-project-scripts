using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public Text levelTxt;
    

    [SerializeField]private DialogueManager dialogueManager;


    private void FixedUpdate() {
        LoadLevel();
    }
    private void LoadLevel()
    {
            levelTxt.text = "Màn " + SceneManager.GetActiveScene().buildIndex;
            Invoke(nameof(LevelTxt), 1.5f);
    }

    private void LevelTxt()
    {
        levelTxt.enabled = false;
    }
}
