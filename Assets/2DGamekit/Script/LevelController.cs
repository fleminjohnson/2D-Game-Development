using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameOverScreen;

    private void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
