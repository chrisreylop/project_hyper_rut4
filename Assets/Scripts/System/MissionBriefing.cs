using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBriefing : MonoBehaviour
{
    public void StartGame()
    {
        //START UR LITTLE ENGINE SOFI LEEETTSSS GOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        //*spanks her*
        Time.timeScale = 1f;
        Destroy(this.gameObject);
        //gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }
}
