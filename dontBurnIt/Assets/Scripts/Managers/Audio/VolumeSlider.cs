using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider, _sfxSlider;

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void MusicVolume()
    {
        AudioManager.Instance.ChangeMusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.ChangeSFXVolume(_sfxSlider.value);
    }
}
