using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform cCDMXMap;
    public Transform cCDMXCoord;
    private float mapDelta;
    private float xDistance;
    private float yDistance;
    private float hypoDistance;

    public void CalculateVariablesToDestiny()
    {
        xDistance = cCDMXCoord.position.x - cCDMXMap.position.x;
        yDistance = cCDMXCoord.position.y - cCDMXMap.position.y;

        hypoDistance = Mathf.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

        mapDelta = hypoDistance / (100.0f / GameManager.gameManagerInstance.progressBarDelta);

        Debug.Log("Distance to CCDM " + hypoDistance);
        Debug.Log("MapMove Delta " + mapDelta);
    }
    public void UpdateMap()
    {
        cCDMXMap.position = Vector3.MoveTowards(cCDMXMap.position, cCDMXCoord.position, (mapDelta * Time.deltaTime));
    }
    void Update()
    {
        //CalculateVariablesToDestiny();
        UpdateMap();
    }
    private void Start()
    {
        CalculateVariablesToDestiny();
        //mapDelta = GameManager.gameManagerInstance.progressBarDelta;
    }
}
