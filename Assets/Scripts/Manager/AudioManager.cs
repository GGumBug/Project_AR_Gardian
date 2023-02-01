using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region instance

    public static AudioManager instance = null;

    #endregion

    public List<AudioClip> bgList = new List<AudioClip>();
    public List<AudioClip> sfxList = new List<AudioClip>();

    public AudioSource bgAudioSource;
    public AudioSource sfxAudioSource;

    private void Awake()
    {
        instance = this;
        AudioSource[] AudioSourceList = GetComponents<AudioSource>();
        bgAudioSource = AudioSourceList[0];
        sfxAudioSource = AudioSourceList[1];
    }
}
