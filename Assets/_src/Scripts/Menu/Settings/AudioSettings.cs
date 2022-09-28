using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PedroAurelio.MenuScreens
{
    public class AudioSettings : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private AudioMixer mixer;
        
        [Header("Exposed Vars")]
        [SerializeField] private string masterVolume = "MasterVolume";
        [SerializeField] private string sfxVolume = "SfxVolume";
        [SerializeField] private string musicVolume = "MusicVolume";
        [SerializeField] private string uiVolume = "UIVolume";

        public void SetMasterVolume(float value) => mixer.SetFloat(masterVolume, Mathf.Log10(value) * 20f);
        public void SetSfxVolume(float value) => mixer.SetFloat(sfxVolume, Mathf.Log10(value) * 20f);
        public void SetMusicVolume(float value) => mixer.SetFloat(musicVolume, Mathf.Log10(value) * 20f);
        public void SetUIVolume(float value) => mixer.SetFloat(uiVolume, Mathf.Log10(value) * 20f);
    }
}