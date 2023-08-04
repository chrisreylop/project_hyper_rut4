using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public GameObject difficultyMenu;
    public GameObject startMenu;
    public GameObject howToPlayScreen;

    public void ShowDifficultyMenu()
    {
        difficultyMenu.SetActive(true);
        startMenu.SetActive(false);
    }
    public void ShowHowToPlayScreen()
    {
        howToPlayScreen.SetActive(true);
        startMenu.SetActive(false);
    }
    public void HideHowToPlayScreen()
    {
        howToPlayScreen.SetActive(false);
        startMenu.SetActive(true);
    }
    public void MediumDifficultyLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}