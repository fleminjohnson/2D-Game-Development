using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }
    public string level1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(GetLevelStatus(level1) == LevelStatus.locked)
        {
            SetLevelStatus(level1, LevelStatus.unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        return (LevelStatus)PlayerPrefs.GetInt(level, 0);

    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int) levelStatus);
    }

}
