using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using PedroAurelio.Data;

namespace PedroAurelio.MenuScreens
{
    public class AudioSettings : AMenuSettings
    {
        [Header("Dependencies")]
        [SerializeField] private AudioMixer mixer;

        [Header("UI Elements")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider uiSlider;
        
        [Header("Exposed Vars")]
        [SerializeField] private string masterVolume = "MasterVolume";
        [SerializeField] private string sfxVolume = "SfxVolume";
        [SerializeField] private string musicVolume = "MusicVolume";
        [SerializeField] private string uiVolume = "UIVolume";

        protected override void UpdateUIValues(SettingsData data = null)
        {
            if (data == null)
                data = _Data;

            masterSlider.SetValueWithoutNotify(data.AudioData.MasterVolume);
            SetMasterVolume(masterSlider.value);

            sfxSlider.SetValueWithoutNotify(data.AudioData.SfxVolume);
            SetSfxVolume(sfxSlider.value);

            musicSlider.SetValueWithoutNotify(data.AudioData.MusicVolume);
            SetMusicVolume(musicSlider.value);

            uiSlider.SetValueWithoutNotify(data.AudioData.UIVolume);
            SetUIVolume(uiSlider.value);
        }

        public override void DiscardChanges()
        {
            DataManager.Instance.LoadData();
            _Data = DataManager.Instance.GetCurrentData();
            UpdateUIValues();
        }

        public override void ResetDefault()
        {
            var currentData = DataManager.Instance.GetCurrentData();
            currentData.AudioData.SetDefaultValues();
            UpdateUIValues(currentData);
        }

        public void SetMasterVolume(float value)
        {
            mixer.SetFloat(masterVolume, Mathf.Log10(value) * 20f);
            _Data.AudioData.MasterVolume = masterSlider.value;
        }

        public void SetSfxVolume(float value)
        {
            mixer.SetFloat(sfxVolume, Mathf.Log10(value) * 20f);
            _Data.AudioData.SfxVolume = sfxSlider.value;
        }

        public void SetMusicVolume(float value)
        {
            mixer.SetFloat(musicVolume, Mathf.Log10(value) * 20f);
            _Data.AudioData.MusicVolume = musicSlider.value;
        }

        public void SetUIVolume(float value)
        {
            mixer.SetFloat(uiVolume, Mathf.Log10(value) * 20f);
            _Data.AudioData.UIVolume = uiSlider.value;
        }
    }
}