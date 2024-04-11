using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public static AudioManager instance;
    public Slider[] sliderList;
    public AudioValues audioValues;
    //public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    /*
    public void MasterUpdate()
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderList[0].value) * 20);
        //Debug.Log(masterVol.ToString());
    }
    */
    public void OnEnable()
    {
        sliderList[0].value = audioValues.musicValue;
        sliderList[1].value = audioValues.voicesValue;
        sliderList[2].value = audioValues.effectsValue;
    }

    public void MusicUpdate()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderList[0].value) * 20);
        audioValues.musicValue = sliderList[0].value;
    }
    public void VoicesUpdate()
    {
        audioMixer.SetFloat("VoicesVolume", Mathf.Log10(sliderList[1].value) * 20);
        audioValues.voicesValue = sliderList[1].value;
    }
    public void EffectsUpdate()
    {
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(sliderList[2].value) * 20);
        audioValues.effectsValue = sliderList[2].value;
    }
}
