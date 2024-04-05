using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "AudioManager";
                    _instance = obj.AddComponent<AudioManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    public AudioSource musicSource;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic(AudioClip music)
    {
        if (musicSource.isPlaying && musicSource.clip == music)
        {
            return; // Music is already playing, do nothing
        }

        musicSource.clip = music;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
