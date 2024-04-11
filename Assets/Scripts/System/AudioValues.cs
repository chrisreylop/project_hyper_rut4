using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "project_hyper_rut4/audioValues")]
public class AudioValues : ScriptableObject
{
    [Header("Audio Slider Values")]
    public float musicValue;
    public float voicesValue;
    public float effectsValue;
}
