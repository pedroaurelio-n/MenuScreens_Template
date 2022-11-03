using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using PedroAurelio.Data;
 
namespace PedroAurelio.MenuScreens
{
    public abstract class AMenuSettings : MonoBehaviour
    {
        [SerializeField] private bool updateValuesOnStart;

        protected SettingsData _Data;

        private void Start()
        {
            _Data = DataManager.Instance.GetCurrentData();

            if (updateValuesOnStart)
                UpdateUIValues();
        }

        protected abstract void UpdateUIValues(SettingsData data = null);

        public void ApplyChanges() => DataManager.Instance.SaveData();

        public abstract void DiscardChanges();

        public abstract void ResetDefault();
    }
}