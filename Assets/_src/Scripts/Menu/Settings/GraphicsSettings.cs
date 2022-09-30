using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PedroAurelio.Data;
 
namespace PedroAurelio.MenuScreens
{
    public class GraphicsSettings : AMenuSettings
    {
        [Header("UI Elements")]
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private TMP_Dropdown qualityDropdown;
        [SerializeField] private Toggle fullscreenToggle;

        protected override void UpdateUIValues(SettingsData data = null)
        {
            if (data == null)
                data = _Data;

            resolutionDropdown.value = data.GraphicsData.ResolutionOption;
            SetResolution(resolutionDropdown.value);

            qualityDropdown.value = data.GraphicsData.Quality;
            SetQuality(qualityDropdown.value);

            fullscreenToggle.isOn = data.GraphicsData.Fullscreen;
            SetFullscreen(fullscreenToggle.isOn);
        }

        public  override void DiscardChanges()
        {
            DataManager.Instance.LoadData();
            _Data = DataManager.Instance.GetCurrentData();
            UpdateUIValues();
        }

        public  override void ResetDefault()
        {
            var currentData = DataManager.Instance.GetCurrentData();
            currentData.GraphicsData.SetDefaultValues();
            UpdateUIValues(currentData);
        }

        public void SetResolution(int value)
        {
            _Data.GraphicsData.ResolutionOption = value;
            ApplyResolutionValues(resolutionDropdown.options[value].text);
        }

        public void SetQuality(int value)
        {
            //change quality
            _Data.GraphicsData.Quality = value;
        }

        public void SetFullscreen(bool value)
        {
            Screen.fullScreen = value;
            _Data.GraphicsData.Fullscreen = value;
        }

        private void ApplyResolutionValues(string resolutionText)
        {
            var values = resolutionText.Split('x');
            var width = int.Parse(values[0]);
            var height = int.Parse(values[1]);

            Screen.SetResolution(width, height, _Data.GraphicsData.Fullscreen, Screen.currentResolution.refreshRate);

            _Data.GraphicsData.ResolutionWidth = width;
            _Data.GraphicsData.ResolutionHeight = height;
        }
    }
}