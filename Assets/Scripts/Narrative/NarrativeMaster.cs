using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeMaster : MonoBehaviour
{
    [Header("Narrative Interface")]
    public Text nameText;
    public Text narrativeText;
    public GameObject narrativeBubble;
    public Dialogue idleDialogue;
    //public InteractTutorial interactTutorial;
    //public KeyCode interactKey = KeyCode.F;
    //public AudioClip greeting;
    [HideInInspector]
    public bool dialogueStarted = false, playerInRangeOfDialogue = false;
    private AudioSource audioSource;
    private Animator textBubbleAnimator;
    private Queue <string> sentences;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //interactTutorial.StartInteractKeyBubble(interactKey);
            playerInRangeOfDialogue = true;
            //audioSource.PlayOneShot (llamada);
            //Debug.Log("Player is in dialogue range");
        }  
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player is out of dialogue range");
            EndDialogueBubble();
            //interactTutorial.interactTutorialAnimator.SetBool("StayAnim", false);
            playerInRangeOfDialogue = false;
            dialogueStarted = false;
        }
    }

    /*public IEnumerator WaitToTalkAgain()
    {
        yield return new WaitForSeconds(1.0f);
        dialogueStarted = false;
        narrativeBubble.SetActive(false);
    }*/

    public void EndDialogueBubble()
    {
        if(dialogueStarted)
        {
            //interactTutorial.StartInteractKeyBubble(interactKey);
        }
        dialogueStarted = false;
        textBubbleAnimator.enabled = false;
        narrativeBubble.SetActive(false);        
        //Debug.Log("End conversation");
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //EndDialogueBubble();
            textBubbleAnimator.SetBool("StayAnim", false);
            return;
        }
        string sentence = sentences.Dequeue();
        narrativeText.text = sentence;
        //Debug.Log(sentence);
    }

    public void StartDialogueBubble()
    {
        narrativeBubble.SetActive(true);
        textBubbleAnimator.enabled = true;
        textBubbleAnimator.SetBool("StayAnim", true);
        textBubbleAnimator.Rebind();
        textBubbleAnimator.Update(0f);
        
        nameText.text = idleDialogue.name;
        sentences.Clear();

        /*foreach (string sentence in idleDialogue.sentence)
        {
            sentences.Enqueue(sentence);
            //Debug.Log(sentence);
        }*/

        DisplayNextSentence();
    }

    public void StartDialogue()
    {
        //Si el jugador esta en rango de dialogo y el dialogo no ha iniciado -> Inicia dialogo
        if (playerInRangeOfDialogue && !dialogueStarted)
        {
            //audioSource.PlayOneShot (greeting);
            //interactTutorial.interactTutorialAnimator.SetBool("StayAnim", false);
            dialogueStarted = true;
            StartDialogueBubble();
            //Debug.Log("Dialogue manager started");
        }
    }

    private void Start()
    {
        sentences = new Queue<string>();
        textBubbleAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        StartDialogue();
    }
}