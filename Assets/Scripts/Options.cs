using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class options : MonoBehaviour


{

    public Slider MusicVol;
    public Slider SfxVol;
    public AudioMixer AudMixer;
    
    public void GraphicsQualityLow()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void GraphicsQualityMed()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void GraphicsQualityHigh()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void ChangeMusicVol()
    {
        AudMixer.SetFloat("Music Vol", MusicVol.value);
    }

    public void ChangeSfxVol()
    {
        AudMixer.SetFloat("Sfx Vol", SfxVol.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
