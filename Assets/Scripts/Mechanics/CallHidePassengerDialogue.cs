using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHidePassengerDialogue : MonoBehaviour
{
    public void HidePassengerDialogue()
    {
        GameManager.gameManagerInstance.HidePassengerDialogue();
    }
}
