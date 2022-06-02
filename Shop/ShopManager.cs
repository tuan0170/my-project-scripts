using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]private GameObject ShopUI;
    [SerializeField]private bool isShopping;

    #region properties
    public bool IsShopping
    {
        get{return isShopping;}
        set{isShopping = value;}
    }
    #endregion

    private void Awake() 
    {
        ShopUI.SetActive(false);
        isShopping = false;    
    }

    private void Update() 
    {
        LoadShop();
    }

    #region method
    private void LoadShop()
    {
        if(isShopping)
        {
            ShopUI.SetActive(true);
        }

        if(!isShopping)
        {
            ShopUI.SetActive(false);
        }
    }
    #endregion
    
    #region event
    public void ShopButton()
    {
        isShopping = true;
    }
    public void ExitShop()
    {
        isShopping = false;
    }
    #endregion
}
