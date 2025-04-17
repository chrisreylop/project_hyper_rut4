using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPickUp : MonoBehaviour
{
    private float smartPickUpSpeed;
    //public GameObject PickUpSpawnerStartPoint;
    /*private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("StageDestroyPoint"))
        {
            GameManager.gameManagerInstance.passengerAlreadySpawned = false;        
            Destroy(this.gameObject);            
        }      
    }*/
    public void MoveSmartPickUp()
    {
        if(transform.position.z < -10.0f)
        {
            GameManager.gameManagerInstance.passengerAlreadySpawned = false;        
            Destroy(this.gameObject);
            //Debug.Log("Destroyed Smart PickUp Correctly");   
        }
        float sinMove;
        //sinMove = 0.025f * Mathf.Cos(Time.time * 1.0f);
        sinMove = 0.1f * Mathf.Sin(Time.fixedDeltaTime * 15.0f * Time.fixedDeltaTime);
        transform.Translate(sinMove, 0f, 1.0f * -Time.fixedDeltaTime * smartPickUpSpeed);
    }
    private void FixedUpdate()
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
