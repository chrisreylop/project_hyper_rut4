using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetMaster : MonoBehaviour
{
    private float courseSpeed;
    private int spawnersSpacingStep;
    public GameObject PickUpSpawner;
    public GameObject PickUpSpawnerStartPoint;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("StageDestroyPoint"))
        {
            //Debug.Log("entered StageDestroyPoint");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("StageDestroyPoint"))
        {
            GameManager.gameManagerInstance.SpawnStage();
            Destroy(this.gameObject);
        }      
    }
    public void MoveCourse()
    {
        //var step = moveSpeed * Time.deltaTime;
        //transform.LookAt(trackCourse[trackPoint]);
        //transform.position = Vector3.MoveTowards(transform.position, trackCourse[trackPoint].position, step);
        transform.Translate(Vector3.forward * -Time.deltaTime * courseSpeed);
    }
    public void SetSpawners()
    {
        for(int i = 0; i < 600; i += spawnersSpacingStep)
        {
            Vector3 tempPos = new Vector3(PickUpSpawnerStartPoint.transform.position.x, PickUpSpawnerStartPoint.transform.position.y, PickUpSpawnerStartPoint.transform.position.z + i);
            GameObject tempGO = Instantiate
            (PickUpSpawner, tempPos, PickUpSpawnerStartPoint.transform.rotation);
            tempGO.transform.SetParent(PickUpSpawnerStartPoint.transform);
        }        
    }
    // Update is called once per frame
    private void Update()
    {
        MoveCourse();
    }
    private void Start()
    {
        if(GameManager.gameManagerInstance != null)
        {
            courseSpeed = GameManager.gameManagerInstance.courseSpeed;
            spawnersSpacingStep = GameManager.gameManagerInstance.spawnersSpacingStep;
        }
        else
        {
            courseSpeed = 0f;
            spawnersSpacingStep = 600;
        }

        SetSpawners();
    }
}
