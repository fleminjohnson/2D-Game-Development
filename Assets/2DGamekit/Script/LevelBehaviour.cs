using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBehaviour : MonoBehaviour
{
    public GameObject sceneChangerPopup;
    public void SceneChanger(int buildIndex)
    {
        LevelStatus levelStatus = UIManager.Instance.GetLevelStatus(NameFromIndex(buildIndex));

        switch (levelStatus)
        {
            case LevelStatus.locked:
                print("Level is Locked");
                break;

            case LevelStatus.unlocked:
                print("LevelUnlocked");
                SceneManager.LoadScene(buildIndex);
                break;

            case LevelStatus.finished:
                print("LevelAlreadyCompleted");
                SceneManager.LoadScene(buildIndex);
                break;
        }
    }

    public void SceneSelector()
    {
        sceneChangerPopup.SetActive(true);
    }

    public static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
}

