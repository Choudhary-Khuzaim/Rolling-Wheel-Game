using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool ganeOver;
    public GameObject gameOverPanel;
    public GameObject startingText;

    public static int numberOfCoins;
    public Text coinsText;

    public static bool isGameStarted;
    void Start()
    {
        ganeOver = false;
        Time.timeScale = 1; 
        isGameStarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ganeOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coinsText.text = "Coins" + numberOfCoins;
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
