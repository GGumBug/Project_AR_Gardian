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
    }

    public void PlayBGM(int a)
    {
        AudioManager.instance.bgAudioSource.clip = AudioManager.instance.bgList[a];
        AudioManager.instance.bgAudioSource.Play();
    }

    public void PlayBattleBGM()
    {
        int a = BattleManager.GetInstance().curGuardian;
        AudioManager.instance.bgAudioSource.clip = AudioManager.instance.bgList[a+1];
        AudioManager.instance.bgAudioSource.Play();
    }
}
