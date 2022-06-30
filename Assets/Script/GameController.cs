using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float health;
    public Image healthBar;
    public GameObject[] spawnPoints;
    public GameObject obstacle;
    public Text obstacleCountText;
    private int obstacleCount = 30;
    public Button[] myButtons;
    public GameObject gameOver;

    void Start()
    {
        health = 100f;
        obstacleCountText.text = obstacleCount.ToString();
    }

    void Update()
    {
        ButtonInteraction();
        GameOver();
    }

    public void ButtonPoints(int index) /*Butonlarý tekrar tekrar yazmak yerine index kullanarak tek fonksiyon üzerinden hallet.*/
    {
        if(obstacleCount > 0)
        {
            obstacleCount--;
            Instantiate(obstacle, spawnPoints[index].transform.position, Quaternion.identity);
            obstacleCountText.text = obstacleCount.ToString();
        }
    }

    public void ButtonInteraction()
    {
        if(obstacleCount == 0)
        {
            foreach (var button in myButtons)
            {
                button.interactable = false;
            }
        }
    }

    public void ReduceHealth(float darbe)
    {
        health -= darbe;
        healthBar.fillAmount = health / 100;
    }

    public void GameOver()
    {
        if(health <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
