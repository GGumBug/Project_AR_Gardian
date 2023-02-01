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
        bgAudioSource.clip = AudioManager.instance.bgList[a];
        instance.bgAudioSource.Play();
    }

    public void PlayBattleBGM()
    {
        int a = BattleManager.GetInstance().curGuardian;
        bgAudioSource.loop = true;
        bgAudioSource.clip = bgList[a+1];
        bgAudioSource.Play();
    }
}
