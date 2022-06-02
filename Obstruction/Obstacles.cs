using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]private int deadZone =2;
    [SerializeField]private GameObject gameOb;

    #region method
    private void Update() 
    {
        DeadZone();
    }
    public void DeadZone()
    {
        if(transform.position.y <= -deadZone) //if position y of player <= deadzone then player die
        {
            DestroyObstacle();
        }
    }

    private void DestroyObstacle()
    {
        Destroy(gameOb);
    }
    #endregion
}
