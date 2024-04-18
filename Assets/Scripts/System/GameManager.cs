using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager gameManagerInstance;
    [Header("Game Logic")]

    public int level;
    public float fuel = 100;
    public float fuelDelta = 0.1f;
    public GameObject spawnPoint;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject passenger;
    public GameObject passengerSpawnPoint;
    public float passengerPickUpSpeed = 0f;
    public float progressBarDelta;
    public float courseSpeed = 0f;
    public int spawnersSpacingStep = 100;

    public EndingsData endingsData;

    //Hidden game logic values
    [HideInInspector]
    public bool passengerAlreadySpawned = true;

    [Header("GUI")]
    public Slider progressBarSlider;
    public Slider fuelLevelBarSlider;
    //public Text scoreText;
    //public Text livesText;
    //private int score;
    //private int lives = 5;

    //NARRATIVE TEXT
    [Header("Narrative Interface")]
    public Text nameText;
    public Text narrativeText;
    public Text narrativeNumber;
    public Image passengerPortrait;
    public GameObject dialogueBox;
    public Dialogue[] passengerDialogues;
    private int passengerDialoguesIndex = 0;
    public Animator dialogueBoxAnimator;

    //NARRATIVE AUDIO
    [Header("Narrative Audio")]
    public AudioSource audioSource;
    public AudioClip[] audioDialogues;
    private int audioClipsIndex;

    //SFX AUDIO
    [Header("Sound Effects Audio")]
    public AudioClip[] soundEffects;
    public AudioSource soundEffectsAudioSource;

    //PARTICLE EFFECTS
    [Header("ParticleSystems")]
    public ParticleSystem[] particleSystems;

    public void ShowPassengerDialogue()
    {
        //Narrative Box: Pass line of dialogue (string), name (string) and portrait (sprite -> image)
        //of passenger to DialogueBox THEN deploy DialogueBox through Animator

        if (passengerDialoguesIndex < passengerDialogues.Length)
        {
            dialogueBox.SetActive(true);

            //Reinicia completamente el animator
            dialogueBoxAnimator.Rebind();
            dialogueBoxAnimator.Update(0f);
            //Reinicia completamente el animator

            dialogueBoxAnimator.SetBool("StayDialogueBox", true);

            nameText.text = passengerDialogues[passengerDialoguesIndex].name;
            passengerPortrait.sprite = passengerDialogues[passengerDialoguesIndex].portrait;
            narrativeText.text = passengerDialogues[passengerDialoguesIndex].sentence;            
            passengerDialoguesIndex++;
            narrativeNumber.text = (passengerDialoguesIndex + "/" + passengerDialogues.Length);

            //Narrative Audio: Play audio clip then increment clip index
            audioSource.clip = audioDialogues[audioClipsIndex];
            audioSource.Play();
            audioClipsIndex++;
        }
    }

    public void CheckIfDialogueIsPlaying()
    {
        if (!audioSource.isPlaying && !Pause.gameIsPaused)
        {
            dialogueBoxAnimator.SetBool("CloseDialogueBox", true);
            if (!passengerAlreadySpawned)
            {
                SpawnPassenger();
                //Debug.Log("Spawn Passenger # " + audioClipsIndex);
            }
        }
    }
    public void HidePassengerDialogue()
    {
        dialogueBoxAnimator.SetBool("StayDialogueBox", false);
        dialogueBox.SetActive(false);
    }
    public void SpawnStage()
    {
        //75 for immersion, 0 for results
        if(progressBarSlider.value > 90)
        {
            Instantiate(stage3, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else if (progressBarSlider.value > 75)
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
        if (fuel < 100)
        {
            fuel = fuel + pickedUpFuel;
        }
        //livesText.text = lives.ToString();
        if (fuel <= 0)
        {
            DeadSequence();
        }
        //Debug.Log(score);
    }
    public void DeadSequence()
    {
        endingsData.level = 2;
        endingsData.youDiedEnding = true;
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("You Died");
    }

    //x=-0.42 y=0.595
    public void WinSequence()
    {
        if (fuel <= 0)
        {
            DeadSequence();
        }
        else if (progressBarSlider.value >= 100)
        {
            //Check for perfect ending
            endingsData.level = level;
            if (passengerDialoguesIndex >= passengerDialogues.Length)
            {
                endingsData.perfectEnding = true;
            }
            else
            {
                endingsData.youFailedEnding = true;
            }

            SceneManager.LoadScene("MainMenu");
            Debug.Log("You Are Winner");
        }
        else
        {
            //Progress Bar advance            
            progressBarSlider.value += Time.deltaTime * progressBarDelta;
            fuel -= Time.deltaTime * fuelDelta;
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
    public void SpawnPassenger()
    {
        passengerAlreadySpawned = true;
        Instantiate(passenger, passengerSpawnPoint.transform);
    }

    //Main
    private void Update()
    {
        WinSequence();
        CheckIfDialogueIsPlaying();
    }
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        SpawnPassenger();
    }
    private void Awake()
    {        
        gameManagerInstance = this;
    }
}
