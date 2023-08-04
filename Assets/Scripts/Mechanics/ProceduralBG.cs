using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralBG : MonoBehaviour
{
    public GameObject [] floorSpawnPoints;
    public GameObject [] borderMountainTilesSpawnPoints;
    public GameObject [] floorTiles;
    public GameObject [] borderMountainTiles;
    public void instanceRandomFloor()
    {
        for(int i = 0; i < floorSpawnPoints.Length; i++)
        {
            int j = Random.Range(0, floorTiles.Length);
            GameObject tempGO = Instantiate
            (floorTiles[j], floorSpawnPoints[i].transform.position, floorSpawnPoints[i].transform.rotation);
            tempGO.transform.SetParent(floorSpawnPoints[i].transform);
        }        
    }
    public void instanceRandomMountains()
    {
        for(int i = 0; i < borderMountainTilesSpawnPoints.Length; i++)
        {
            int j = Random.Range(0, borderMountainTiles.Length);
            GameObject tempGO = Instantiate
            (borderMountainTiles[j], borderMountainTilesSpawnPoints[i].transform.position, borderMountainTilesSpawnPoints[i].transform.rotation);
            tempGO.transform.position = new Vector3
            (tempGO.transform.position.x, tempGO.transform.position.y, tempGO.transform.position.z);
            tempGO.transform.localScale = new Vector3
            ((tempGO.transform.localScale.x * Random.Range(0,2)*2-1), tempGO.transform.localScale.y, (tempGO.transform.localScale.z * Random.Range(0,2)*2-1));
            tempGO.transform.SetParent(borderMountainTilesSpawnPoints[i].transform);
        }        
    }
    void Start()
    {
        instanceRandomFloor();
        instanceRandomMountains();
    }
}
