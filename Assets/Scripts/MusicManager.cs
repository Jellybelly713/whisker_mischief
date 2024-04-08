using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    // Reference to the AudioSource component
    public AudioSource audioSource;

    void Update()
    {

        // Check if the audio is playing, and if not, start playing it
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

