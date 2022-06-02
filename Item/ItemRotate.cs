using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float speedZ;
    void Update()
    {
        Rotate();
    }
    #region method
    private void Rotate() //item will rotate 360
    {
        transform.Rotate(360 * speedX *Time.deltaTime, 360 * speedY *Time.deltaTime, 360 * speedZ *Time.deltaTime);
    }
    #endregion
    
}
