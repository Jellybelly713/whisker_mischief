using UnityEngine;

public class PlayMusicInScene : MonoBehaviour
{
    public AudioClip musicToPlay;

    void Start()
    {
        AudioManager.Instance.PlayMusic(musicToPlay);
    }
}
