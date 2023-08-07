using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPickUp : MonoBehaviour
{
    private float smartPickUpSpeed;
    //public GameObject PickUpSpawnerStartPoint;
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("StageDestroyPoint"))
        {
            GameManager.gameManagerInstance.passengerAlreadySpawned = false;        
            Destroy(this.gameObject);            
        }      
    }
    public void MoveSmartPickUp()
    {
        float sinMove;
        sinMove = 0.025f * Mathf.Cos(Time.time * 1.0f);
        transform.Translate(sinMove, 0f, 1.0f * -Time.deltaTime * smartPickUpSpeed);
    }
    private void Update()
    {
        if(!Pause.gameIsPaused)
        {
            MoveSmartPickUp();
        }
    }
    private void Start()
    {
        smartPickUpSpeed = GameManager.gameManagerInstance.passengerPickUpSpeed;
    }
}
