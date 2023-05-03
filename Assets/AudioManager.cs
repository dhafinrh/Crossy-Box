using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm, sfx;

    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }
    public float SfxVolume { get => sfx.volume; }
    private void Awake()
    {
        bgm.mute = PlayerPrefs.GetInt("Mute") == 1 ? true : false;
        sfx.mute = PlayerPrefs.GetInt("Mute") == 1 ? true : false;
        bgm.volume = PlayerPrefs.GetFloat("BGM Volume", 0.2f);
        sfx.volume = PlayerPrefs.GetFloat("SFX Volume", 0.5f);

    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }
        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfx.isPlaying)
        {
            sfx.Stop();
        }
        sfx.clip = clip;
        sfx.Play();
    }

    public void Mute(bool value)
    {
        bgm.mute = value;
        sfx.mute = value;
        PlayerPrefs.SetInt("Mute", value ? 1 : 0);
    }
    public void SetBGMVolume(float value)
    {
        bgm.volume = value;
        PlayerPrefs.SetFloat("BGM Volume", value);
    }

    public void SetSFXVolume(float value)
    {
        sfx.volume = value;
        PlayerPrefs.SetFloat("SFX Volume", value);
    }
}
