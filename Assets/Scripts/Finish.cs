using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject WinPanel;
    public ParticleSystem WinParticles;
    void OnTriggerEnter(Collider other)
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex >= Constants.LevelCount - 1)
        {
            if (WinPanel != null)
            {

                WinPanel.SetActive(true);
            }

            if (WinParticles != null)
            {

                WinParticles?.Play();
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
