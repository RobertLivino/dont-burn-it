using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("VolumeValue");
    }

    public void ChangeVolume(float volume)
    {
      SoundManager.Instance.ChangeMasterVolume(volume);
    }

}
