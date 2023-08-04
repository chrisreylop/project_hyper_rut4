using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawnerMaster : MonoBehaviour
{
    public GameObject [] pickUpSpawns;
    public GameObject heartModel, dronModel, passenger;
    public void SpawnAllPickUps()
    {
        int i = Random.Range(0, pickUpSpawns.Length);
        pickUpSpawns[i].SetActive(true);
        //for(int i = 0; i < pickUpSpawns.Length; i++)
        {
            GameObject tempGO;
            if(i == 0 || i == 4)
            {
                int rand = Random.Range (0,3);
                if(rand == 0)
                {
                    //Passenger
                    tempGO = Instantiate(passenger, pickUpSpawns[i].transform.position, pickUpSpawns[i].transform.rotation);
                    tempGO.transform.SetParent(pickUpSpawns[i].transform);
                    pickUpSpawns[i].GetComponent<PickUpType>().pickUpType = 0;
                }
                else if(rand == 1)
                {
                    //Heart
                    tempGO = Instantiate(heartModel, pickUpSpawns[i].transform.position, pickUpSpawns[i].transform.rotation);
                    tempGO.transform.SetParent(pickUpSpawns[i].transform);
                    pickUpSpawns[i].GetComponent<PickUpType>().pickUpType = 1;
                }
                else if(rand == 2)
                {
                    //Dron
                    tempGO = Instantiate(dronModel, pickUpSpawns[i].transform.position, pickUpSpawns[i].transform.rotation);
                    tempGO.transform.SetParent(pickUpSpawns[i].transform);
                    pickUpSpawns[i].GetComponent<PickUpType>().pickUpType = 2;
                }
            }
            else
            {
                int rand = Random.Range (0,2);
                if(rand == 0)
                {
                    //Heart
                    tempGO = Instantiate(heartModel, pickUpSpawns[i].transform.position, pickUpSpawns[i].transform.rotation);
                    tempGO.transform.SetParent(pickUpSpawns[i].transform);
                    pickUpSpawns[i].GetComponent<PickUpType>().pickUpType = 1;
                }
                else
                {
                    //Dron
                    tempGO = Instantiate(dronModel, pickUpSpawns[i].transform.position, pickUpSpawns[i].transform.rotation);
                    tempGO.transform.SetParent(pickUpSpawns[i].transform);
                    pickUpSpawns[i].GetComponent<PickUpType>().pickUpType = 2;
                }
            }
        }
    }
    private void Start()
    {
        SpawnAllPickUps();
    }
}
