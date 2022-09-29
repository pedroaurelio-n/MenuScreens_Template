using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using PedroAurelio.Data;

namespace PedroAurelio.MenuScreens
{
    public class AudioSettings : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private AudioMixer mixer;

        [Header("Sliders")]
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider uiSlider;
        
        [Header("Exposed Vars")]
        [SerializeField] private string masterVolume = "MasterVolume";
        [SerializeField] private string sfxVolume = "SfxVolume";
        [SerializeField] private string musicVolume = "MusicVolume";
        [SerializeField] private string uiVolume = "UIVolume";

        private AudioData _data;

        private void Start()
        {
            _data = DataManager.Instance.GetCurrentData().AudioData;
            UpdateSliderValues();
        }

        private void UpdateSliderValues(AudioData data = null)
        {
            if (data == null)
                data = _data;

            masterSlider.value = data.MasterVolume;
            SetMasterVolume(masterSlider.value);

            sfxSlider.value = data.SfxVolume;
            SetSfxVolume(sfxSlider.value);

            musicSlider.value = data.MusicVolume;
            SetMusicVolume(musicSlider.value);

            uiSlider.value = data.UIVolume;
            SetUIVolume(uiSlider.value);
        }

        public void ApplyChanges()
        {
            DataManager.Instance.SaveData();
            UpdateSliderValues();
        }

        public void DiscardChanges()
        {
            _data = DataManager.Instance.LoadData().AudioData;
            UpdateSliderValues();
        }

        public void ResetDefault()
        {
            var fullData = DataManager.Instance.GetCurrentData().AudioData;
            fullData.SetDefaultValues();
            UpdateSliderValues(fullData);
        }

        public void SetMasterVolume(float value)
        {
            mixer.SetFloat(masterVolume, Mathf.Log10(value) * 20f);
            _data.MasterVolume = masterSlider.value;
        }

        public void SetSfxVolume(float value)
        {
            mixer.SetFloat(sfxVolume, Mathf.Log10(value) * 20f);
            _data.SfxVolume = sfxSlider.value;
        }

        public void SetMusicVolume(float value)
        {
            mixer.SetFloat(musicVolume, Mathf.Log10(value) * 20f);
            _data.MusicVolume = musicSlider.value;
        }

        public void SetUIVolume(float value)
        {
            mixer.SetFloat(uiVolume, Mathf.Log10(value) * 20f);
            _data.UIVolume = uiSlider.value;
        }
    }
}