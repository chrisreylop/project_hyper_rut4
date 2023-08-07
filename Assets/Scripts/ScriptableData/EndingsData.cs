using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "project_hyper_rut4/EndingsData")]
public class EndingsData : ScriptableObject
{
    [Header("Level")]
    public int level = 0;

    [Header("Game Over Endings")]
    public bool youDiedEnding;
    public bool youFailedEnding;
    public bool perfectEnding;


    [Header("Perfect Endings")]
    public bool easyPerfectEnding;
    public bool mediumPerfectEnding;
    public bool hardPerfectEnding;
    public bool truePerfectEnding;
}
