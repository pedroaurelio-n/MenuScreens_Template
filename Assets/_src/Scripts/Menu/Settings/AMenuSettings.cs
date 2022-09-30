using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using PedroAurelio.Data;
 
namespace PedroAurelio.MenuScreens
{
    public abstract class AMenuSettings : MonoBehaviour
    {
        protected SettingsData _Data;

        private void Start()
        {
            _Data = DataManager.Instance.GetCurrentData();
            UpdateUIValues();
        }

        protected abstract void UpdateUIValues(SettingsData data = null);

        public void ApplyChanges() => DataManager.Instance.SaveData();

        public abstract void DiscardChanges();

        public abstract void ResetDefault();
    }
}