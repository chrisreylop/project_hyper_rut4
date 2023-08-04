using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public void MoveBus()
    {
        if(transform.position.x > -3.5)
        {
            if(Input.GetAxis("Horizontal") < 0 )
            {
                float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
                transform.Translate(moveAmount, 0, 0);
                //Debug.Log(Input.GetAxis("Horizontal") + "move left");
            }
        }
        if(transform.position.x < 3.5)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
                transform.Translate(moveAmount, 0, 0);
                //Debug.Log(Input.GetAxis("Horizontal") + "move right");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Passenger"))
        {
            GameManager.gameManagerInstance.ShowPassengerDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBus();
    }
}
