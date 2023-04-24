using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _MainMenu;
    private GameObject _LevelSelectMenu;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _MainMenu = GameObject.Find("MainMenu");
        _LevelSelectMenu = GameObject.Find("LevelSelectMenu");

        _LevelSelectMenu.SetActive(false);
    }

    public void ShowLevelSelect() {
        _MainMenu.SetActive(false);
        _LevelSelectMenu.SetActive(true);
    }

    public void SelectLevel(int levelIndex) {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelIndex);
    }

    public void Back() {
        _LevelSelectMenu.SetActive(false);
        _MainMenu.SetActive(true);
    }
}
