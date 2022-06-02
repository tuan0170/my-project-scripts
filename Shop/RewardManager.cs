using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    
    [SerializeField]private float point;

    [SerializeField]private int coin;

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
    #endregion
}
