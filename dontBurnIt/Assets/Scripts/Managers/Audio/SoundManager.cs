using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _effectsSource;
    [SerializeField] private AudioSource _musicSource;

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

        LoadVolume();
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        PlayerPrefs.SetFloat("VolumeValue", value);
        AudioListener.volume = value;
    }

    private void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        AudioListener.volume = volumeValue;
    }


}
