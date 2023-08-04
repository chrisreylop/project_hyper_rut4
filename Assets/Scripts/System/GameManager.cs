using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager gameManagerInstance;
    [Header("Game Logic")]

    public float fuel = 100;
    public float fuelDelta = 0.1f;
    public GameObject spawnPoint;
    public GameObject stage1;
    public GameObject stage2;
    public float progressBarDelta;
    public float courseSpeed = 0f;
    public int spawnersSpacingStep = 100;
    
    [Header("GUI")]
    public Slider progressBarSlider;
    public Slider fuelLevelBarSlider;
    public Text scoreText;
    public Text livesText;
    private int score;
    private int lives = 5;

    //NARRATIVE TEXT
    [Header("Narrative Interface")]
    public Text nameText;
    public Text narrativeText;
    public Image passengerPortrait;
    public GameObject dialogueBox;
    public Dialogue [] passengerDialogues;
    private int passengerDialoguesIndex = 0;
    public Transform CDMXMap;
    public Animator dialogueBoxAnimator;

    //NARRATIVE AUDIO
    [Header("Narrative Audio")]
    public AudioSource audioSource;
    public AudioClip [] audioDialogues;
    private int audioClipsIndex;

    //SFX AUDIO
    [Header("Sound Effects Audio")]
    public AudioClip [] soundEffects;
    public AudioSource soundEffectsAudioSource;

    public void ShowPassengerDialogue()
    {

        /*
        Narrative Box: Pass line of dialogue (string), name (string) and portrait (sprite -> image)
        of passenger to DialogueBox THEN deploy DialogueBox through Animator
        */

        dialogueBox.SetActive(true);

        //Reinicia completamente el animator
        dialogueBoxAnimator.Rebind();
        dialogueBoxAnimator.Update(0f);

        dialogueBoxAnimator.SetBool("StayDialogueBox", true);

        nameText.text = passengerDialogues[passengerDialoguesIndex].name;
        passengerPortrait.sprite = passengerDialogues[passengerDialoguesIndex].portrait;
        narrativeText.text = passengerDialogues[passengerDialoguesIndex].sentence;

        passengerDialoguesIndex++;

        /*
        Narrative Audio: Play audio clip then increment clip index
        */

        audioSource.clip = audioDialogues[audioClipsIndex];
        audioSource.Play();
        
        audioClipsIndex++;
    }

    public void CheckIfDialogueIsPlaying()
    {
        if(!audioSource.isPlaying)
        {
            dialogueBoxAnimator.SetBool("CloseDialogueBox", true);
        }  
    }
    public void HidePassengerDialogue()
    {
        dialogueBoxAnimator.SetBool("StayDialogueBox", false);
        dialogueBox.SetActive(false);
    }
    public void SpawnStage()
    {
        if(progressBarSlider.value > 0)
        {
            Instantiate(stage2, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else
        {
            Instantiate(stage1, spawnPoint.transform.position, spawnPoint.transform.rotation);
            //Debug.Log("spawn stage 1");
        }
    }

    /*public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        //Debug.Log(score);
    }*/
    public void UpdateFuel(int pickedUpFuel, int typeOfInstance)
    {
        SfxType(typeOfInstance);
        if(fuel < 100)
        {
            fuel = fuel + pickedUpFuel;
        }
        
        //livesText.text = lives.ToString();
        if(fuel == 0)
        {
            DeadSequence();
        }            
        //Debug.Log(score);
    }
    public void DeadSequence()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("You Died");
    }

    //x=-0.42 y=0.595
    public void WinSequence()
    {
        if(fuel <= 0)
        {
            DeadSequence();
        }
        else if(progressBarSlider.value >= 100)
        {
            SceneManager.LoadScene("WinScreen");
            Debug.Log("Winner you");
        }
        else
        {
            //Progress Bar advance            
            CDMXMap.position = new Vector3(CDMXMap.position.x - 0.00005f, CDMXMap.position.y + 0.00005f, CDMXMap.position.z);
            progressBarSlider.value += Time.deltaTime * progressBarDelta;
            fuel -= fuelDelta;
            fuelLevelBarSlider.value = fuel;            
        }
    }
    public void SfxType(int sfxTypeIndex)
    {
        switch (sfxTypeIndex)
        {
            //Picked Up Fuel
            case 0:
                soundEffectsAudioSource.clip = soundEffects[0];
                soundEffectsAudioSource.Play();
            break;

            case 1:
                soundEffectsAudioSource.clip = soundEffects[1];
                soundEffectsAudioSource.Play();
            break;

            case 2:
                soundEffectsAudioSource.clip = soundEffects[2];
                soundEffectsAudioSource.Play();
            break;
        }       
    }
    void Update()
    {
        WinSequence();
        CheckIfDialogueIsPlaying();    
    }
    private void Awake()
    {
        gameManagerInstance = this;
    }
}
