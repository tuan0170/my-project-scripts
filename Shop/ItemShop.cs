using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{

    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private RewardManager rewardManager;
    [Header("jump buff")]
    [SerializeField]private int jumpBuff = 2;
    [SerializeField]private int coinNeededForJumpBuff = 2;
    [Header("speed buff")]
    [SerializeField]private float speedBuff = 0.4f;
    [SerializeField]private int coinNeededForSpeedBuff = 1;

    [Header("Resistance buff")]
    [SerializeField]private bool effectResistanceBuff = false;
    [SerializeField]private int coinNeededForResistanceBuff= 3;

    #region properties
        public bool EffectResistanceBuff
        {
            get{return effectResistanceBuff;}
            set{effectResistanceBuff = value;}
        }
    #endregion

    private void Awake() 
    {
        effectResistanceBuff = false;
    }
    

    public void SpeedBuff()
    {
        if(rewardManager.Coin >= coinNeededForSpeedBuff)
        {
            rewardManager.Coin -= coinNeededForSpeedBuff;
            playerMovement.M_moveSpeed +=  speedBuff;
        }
        else
        {
            Debug.Log("ko");
        }

    }

    public void JumpTimesBuff()
    {
        if( rewardManager.Coin  >= coinNeededForJumpBuff )
        {
            rewardManager.Coin -= coinNeededForJumpBuff;
            playerMovement.M_jumpForce += jumpBuff;
        }

        else
        {
            Debug.Log("ko");
        }
    }

    public void EffectResistance()
    {
        if( rewardManager.Coin  >= coinNeededForResistanceBuff )
        {
            rewardManager.Coin -= coinNeededForResistanceBuff;
            effectResistanceBuff = true;
        }
        else
        {
            Debug.Log("ko");
        }
    }
}
