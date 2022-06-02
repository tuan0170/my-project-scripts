using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField]private Text speedText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text foodText;

    [Header("link")]
    [SerializeField]private PlayerMovement player;
    [SerializeField]private RewardManager rewardManager;
    [SerializeField]private ItemCollector itemCollector;
    private void Update() 
    {
        TextUIUpdate();
    }
    #region method 
    private void TextUIUpdate()//show text
    {
        speedText.text = "Tốc độ: "+ player.M_moveSpeed;
        coinText.text = "Vàng: " + rewardManager.Coin;
        foodText.text = "Thức ăn: "+ itemCollector.Food + "/"+ itemCollector.FoodTotal;
    }
    #endregion
}
