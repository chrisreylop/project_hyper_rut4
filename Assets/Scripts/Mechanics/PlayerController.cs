using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 50.0f;
    public KeyCode jumpKey = KeyCode.Space;
    public float gravityForce = -20f;
    public float thrust = 20f;
    private float maxThrust;
    private bool jumping = false;
    public void MoveBus()
    {
        if (transform.position.x > -3.5)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
                transform.Translate(moveAmount, 0, 0);
                //Debug.Log(Input.GetAxis("Horizontal") + "move left");
            }
        }
        if (transform.position.x < 3.5)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
                transform.Translate(moveAmount, 0, 0);
                //Debug.Log(Input.GetAxis("Horizontal") + "move right");
            }
        }
    }

    public void Jump()
    {
        if (Input.GetKey(jumpKey))
            jumping = true;
        /*if(transform.position.y > 0.6 && maxThrust <= 0)
        {
            transform.Translate(0, gravityForce * Time.deltaTime, 0);
            if(transform.position.y <= 0.6 && maxThrust <= 0)
            {
                maxThrust = thrust;                
            }
        }
        if (Input.GetKey(jumpKey))
        {
            transform.Translate(0, maxThrust * Time.deltaTime, 0);
            if(maxThrust > 0)
                maxThrust -= 1f;            
            Debug.Log("Jumped");
        }     
        else if(transform.position.y > 0.6)
        {
            transform.Translate(0, gravityForce * Time.deltaTime, 0);
        }
        else if(transform.position.y > 0.6)
        {
            transform.Translate(0, gravityForce * Time.deltaTime, 0);
        }                

        if(maxThrust <= 0 && transform.position.y <= 0.6)
            maxThrust = thrust;

        Debug.Log("pressed Jumped");
        */
    }

    public void OnAir()
    {
        if (jumping && maxThrust > 0)
        {
            transform.Translate(0, maxThrust * Time.deltaTime, 0);
            maxThrust -= 1f;
            //Debug.Log("Jumped");
        }
        else if (transform.position.y > 0.6)
        {
            transform.Translate(0, gravityForce * Time.deltaTime, 0);
        }
        if (transform.position.y <= 0.6)
        {
            maxThrust = thrust;
            jumping = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Passenger"))
        {
            GameManager.gameManagerInstance.ShowPassengerDialogue();
            GameManager.gameManagerInstance.UpdateFuel(30, 0);
            GameManager.gameManagerInstance.passengerAlreadySpawned = false;
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        maxThrust = thrust;
    }
    // Update is called once per frame
    void Update()
    {
        OnAir();
        Jump();
        MoveBus();
    }
}
