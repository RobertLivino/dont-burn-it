using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private List<AudioClip> musicSounds;
    [SerializeField] private List<AudioClip> sfxSounds;

    [SerializeField] private AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume");

        PlayMusic();
    }

    public void PlayMusic(string name = null)
    {

        if(name == null)
        {
            Debug.Log("Playing Theme at Start");
            musicSource.Play();
        }
        else
        {
            AudioClip s = musicSounds.Find(x => x.name == name);

            if (s == null)
            {
                Debug.Log("Music not found");
            }
            else
            {
                musicSource.PlayOneShot(s);
                Debug.Log("Playing " + name);
            }
        }

         
    }

    public void PlaySFX(string name)
    {
        AudioClip s = sfxSounds.Find(x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found");
        }
        else
        {
            sfxSource.PlayOneShot(s);
            Debug.Log("Playing " + name);
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

}
