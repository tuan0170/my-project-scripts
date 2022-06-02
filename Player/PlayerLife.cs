using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int deadZone =2;

    public Rigidbody rb;
    private bool dead = false;
    [SerializeField]private DialogueManager dialogueManager;
    #region properties
    public bool Dead
    {
        get{return dead;}
        set{dead = value;}
    }
    

    #endregion
    private void Update() {
        DeadZone();
    }

    #region method
    private void DeadZone()
    {
        if(transform.position.y <= -deadZone && !dead) //if position y of player <= deadzone then player die
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        dead = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel), 1.3f);// perfom reloadlevel after 1.3s
        
    }

    #endregion

    #region event
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
    
}
