using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpType : MonoBehaviour
{
    [HideInInspector]
    public int pickUpType;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(pickUpType == 0)
            {
                GameManager.gameManagerInstance.UpdateFuel(30, 0);
                //Debug.Log("Picked Up 30 fuel");
            }
            else if(pickUpType == 1)
            {
                GameManager.gameManagerInstance.UpdateFuel(10, 1);
                //Debug.Log("Picked Up 10 fuel");
            }
            else if(pickUpType == 2)
            {
                GameManager.gameManagerInstance.UpdateFuel(-10, 2);
                //Debug.Log("Picked dron lost 10 fuel");
            }
            Destroy(this.gameObject);
        }        
    }
}
