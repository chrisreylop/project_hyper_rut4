using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Start Menu Frames")]
    public GameObject startFrame;
    public GameObject instructionsFrame;
    public GameObject levelDifficultyFrame;
    public GameObject endingMessageFrame;
    public Image endingMessage;

    [Header("Ending Images")]
    public Sprite youDiedImage;
    public Sprite youFailedImage;
    public Sprite easyPerfectImage;
    public Sprite mediumPerfectImage;
    public Sprite hardPerfectImage;
    public Sprite truePerfectImage;

    public EndingsData endingsData;

    public void ShowDifficultyMenu()
    {
        levelDifficultyFrame.SetActive(true);
        startFrame.SetActive(false);
    }
    public void ShowHowToPlayScreen()
    {
        instructionsFrame.SetActive(true);
        startFrame.SetActive(false);
    }
    public void HideHowToPlayScreen()
    {
        instructionsFrame.SetActive(false);
        startFrame.SetActive(true);
    }
    public void MediumDifficultyLevel()
    {
        SceneManager.LoadScene("MediumGame");
    }
    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
    public void CheckEndingStatus()
    {
        if (endingsData.level > 0)
        {
            startFrame.SetActive(false);
            endingMessageFrame.SetActive(true);
            if (endingsData.youDiedEnding == true)
            {
                endingMessage.sprite = youDiedImage;
            }
            else if (endingsData.youFailedEnding == true)
            {
                endingMessage.sprite = youFailedImage;
            }
            else if (endingsData.perfectEnding)
            {
                switch (endingsData.level)
                {
                    case 1:
                        {
                            endingsData.easyPerfectEnding = true;
                            endingMessage.sprite = easyPerfectImage;
                            break;
                        }
                    case 2:
                        {
                            endingsData.mediumPerfectEnding = true;
                            endingMessage.sprite = mediumPerfectImage;
                            break;
                        }
                    case 3:
                        {
                            endingsData.hardPerfectEnding = true;
                            endingMessage.sprite = hardPerfectImage;
                            break;
                        }
                }
            }
        }
        EndingsDataResetter();
    }
    public void CloseEndingMessageFrame()
    {
        if (endingsData.easyPerfectEnding == true
        && endingsData.mediumPerfectEnding == true
        && endingsData.hardPerfectEnding == true)
        {
            //Achieved true perfect ending -> Get reward
            endingMessage.sprite = truePerfectImage;

            //Reset true ending progress
            endingsData.easyPerfectEnding = false;
            endingsData.mediumPerfectEnding = false;
            endingsData.hardPerfectEnding = false;
        }
        else
        {
            endingMessageFrame.SetActive(false);
        }
        startFrame.SetActive(true);
    }
    public void EndingsDataResetter()
    {
        endingsData.perfectEnding = false;
        endingsData.youDiedEnding = false;
        endingsData.youFailedEnding = false;
        endingsData.level = 0;
    }
    void Start()
    {
        CheckEndingStatus();
    }
}