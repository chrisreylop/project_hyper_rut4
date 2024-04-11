using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // :::Luis Barcenas:::
    // El script sirve para activar y desactivar elementos usando botones de ui
    
    public GameObject[] pantallas;
    public int activa;
    public int desactiva;
    public AudioSource UIAudioSource;
    public AudioClip selectBtn_sfx;
    public bool scaleOnMouse = false;
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
        Play_selectSfx();
        //Poemos insertar una corutina para que el sonido del botón "jugar" pueda reproducirse completo
        //antes del salto de escena. En este segundo también podemos insertar un black fade. Lo dejo a consideración
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        Play_selectSfx();
    }
    public void Activador()
    {
        pantallas[activa].SetActive(true);
        Play_selectSfx();
    }
    public void Desactivador()
    {
        pantallas[desactiva].SetActive(false);
        Play_selectSfx();
    }
    public void OnExitClick()
    {
        Application.Quit();
        Play_selectSfx();
    }

    /*public void PlayUISound(int sound)
    {
        //UIAudioSource.clip = AudioManager.instance.uiSounds[sound];
        UIAudioSource.Play();
    }*/

    public void Play_selectSfx ()
    {
        if(UIAudioSource != null) 
        {
            UIAudioSource.clip = selectBtn_sfx;
            UIAudioSource.Play();
        }
    }

    public void OnMouseOver()
    {
        if(scaleOnMouse)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }

    }
    public void OnMouseExit()
    {
        if (scaleOnMouse)
        {
            transform.localScale = Vector3.one;
        }
    }
    public void OpenChannel(string url)
    {
        Application.OpenURL(url);
    }
}

