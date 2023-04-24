using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pausePanel;
    public GameObject _selectLevelPanel;
    void Start()
    {
        _pausePanel.SetActive(false);
        _selectLevelPanel.SetActive(false);
    }

    public void PauseClicked()
    {
        Debug.Log("Pause Click");
        _pausePanel.SetActive(true);
        _selectLevelPanel.SetActive(false);

        Time.timeScale = 0;
    }

    public void SelectLevelClicked()
    {
        _pausePanel.SetActive(false);
        _selectLevelPanel.SetActive(true);
    }

    public void ContinueClicked()
    {
        _pausePanel.SetActive(false);
        _selectLevelPanel.SetActive(false);

        Time.timeScale = 1;
    }
    public void MainMenuClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
