using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
public class Settings : MonoBehaviour
{
    public AudioMixer am;
    Resolution[] rsl;
    List<string> resolutions;
    public TMP_Dropdown dropdown;
    public bool isFullScreen = false;
    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("Volume", sliderValue);
    }
    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
}
