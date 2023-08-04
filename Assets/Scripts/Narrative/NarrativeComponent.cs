using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeComponent : MonoBehaviour
{
    public Dialogue dialogue;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.gameManagerInstance.ShowPassengerDialogue();
        }
    }
}
