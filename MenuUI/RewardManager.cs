using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField]private float point;

    [SerializeField]private int coin;

    

    [SerializeField]private int totalCoin;

    #region properties
        public float Point
        {
            get{return point;}
            set{point = value;}
        }

        public int Coin
        {
            get{return coin;}
            set{coin = value;}
        }

        public int TotalCoin
        {
            get{return totalCoin;}
            set{totalCoin = value;}
        }
    #endregion
}
