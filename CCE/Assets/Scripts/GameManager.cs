using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coinAmount;
    
    private void Start() 
    {
        coinText.text = "Score: 0";
    }
    public void GetCoin()
    {
        coinAmount++;
        coinText.text = "Score: " + coinAmount.ToString();
    }
}
