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
    public AudioSource playerSfxAudioSource;

    private void Awake()
    {
        instance = this;
    }

    public void PlayBGM(int a)
    {
        bgAudioSource.clip = bgList[a];
        instance.bgAudioSource.Play();
    }

    public void PlayBattleBGM()
    {
        int a = BattleManager.GetInstance().curGuardian;
        bgAudioSource.loop = true;
        bgAudioSource.clip = bgList[a+1];
        bgAudioSource.Play();
    }

    public void GuardianAttackSound(int b, int c)
    {
        int a = Random.Range(b, c);

        sfxAudioSource.clip = sfxList[a];
        sfxAudioSource.Play();
    }

    public void GuardianSFXPlay(int a)
    {
        sfxAudioSource.clip = sfxList[a];
        sfxAudioSource.Play();
    }

    public void PlayerAttackSound(int b, int c)
    {
        int a = Random.Range(b, c);

        playerSfxAudioSource.clip = sfxList[a];
        playerSfxAudioSource.Play();
    }

    public void PlayerSFXPlay(int a)
    {
        playerSfxAudioSource.clip = sfxList[a];
        playerSfxAudioSource.Play();
    }
}
