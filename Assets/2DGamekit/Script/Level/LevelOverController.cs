using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelOverController : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameOverScreen;
    public TMP_Text point;

    public static int score;


    private void Start()
    {
        gameOver = false;
        score = 0;
    }

    private void Update()
    {
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }

        point.text = "Score : " + score; 
    }
}
