using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public GameObject nextStage;
    private int nextSceneIndex;

    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            var currentScene = SceneManager.GetActiveScene();
            UIManager.Instance.SetLevelStatus(currentScene.name, LevelStatus.finished);
            nextSceneIndex = currentScene.buildIndex + 1;
            var nextScene = LevelBehaviour.NameFromIndex(nextSceneIndex);
            UIManager.Instance.SetLevelStatus(nextScene, LevelStatus.unlocked);
            nextStage.SetActive(true);
        }
    }

    public void NextSceneButton()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
