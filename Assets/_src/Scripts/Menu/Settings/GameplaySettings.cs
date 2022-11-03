using UnityEngine;
using UnityEngine.UI;
using PedroAurelio.Data;
 
namespace PedroAurelio.MenuScreens
{
    public class GameplaySettings : AMenuSettings
    {
        [Header("UI Elements")]
        [SerializeField] private Toggle invertYToggle;
        [SerializeField] private Toggle showFpsToggle;

        protected override void UpdateUIValues(SettingsData data = null)
        {
            if (data == null)
                data = _Data;

            invertYToggle.SetIsOnWithoutNotify(data.GameplayData.InvertY);
            SetInvertY(invertYToggle.isOn);

            showFpsToggle.SetIsOnWithoutNotify(data.GameplayData.ShowFps);
            SetShowFps(showFpsToggle.isOn);
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
            currentData.GameplayData.SetDefaultValues();
            UpdateUIValues(currentData);
        }

        public void SetInvertY(bool value)
        {
            Debug.Log($"Invert Y");
            _Data.GameplayData.InvertY = value;
        }

        public void SetShowFps(bool value)
        {
            Debug.Log($"Show FPS");
            _Data.GameplayData.ShowFps = value;
        }
    }
}