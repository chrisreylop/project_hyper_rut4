using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseFrame;
    public GameObject pauseMenu;
    public GameObject configMenu;
    
    public AudioSource voiceAudioSource;

    public KeyCode pauseKey;

    public void PauseKey()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            if(gameIsPaused)
            {
                ContinueGame();
            }
            else if(!gameIsPaused)
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        if(voiceAudioSource.isPlaying)
        {
            voiceAudioSource.Pause();            
        }
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseFrame.SetActive(true);
    }
    public void ContinueGame()
    {
        gameIsPaused = false;

        if(!voiceAudioSource.isPlaying)
        {
            voiceAudioSource.UnPause();            
        }

        Time.timeScale = 1f;
        configMenu.SetActive(false);
        pauseMenu.SetActive(true);    
        pauseFrame.SetActive(false);
    }
    public void MainMenu()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;        
        SceneManager.LoadScene("MainMenu");
    }
    public void ConfigMenu()
    {
        pauseMenu.SetActive(false);
        configMenu.SetActive(true);
    }
    public void CloseConfigMenu()
    {
        configMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    void Update()
    {
        PauseKey();
    }
}
