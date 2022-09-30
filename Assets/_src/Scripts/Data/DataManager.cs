using System.IO;
using UnityEngine;
 
namespace PedroAurelio.Data
{
    public class DataManager : MonoBehaviour
    {
        #region Singleton/Awake
        public static DataManager Instance;

        private void Awake()
        {
            _settingsDataPath = Path.Combine(Application.persistentDataPath, "SettingsData.json");

            InitializeData();

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
        #endregion

        private SettingsData SettingsData;
        private static string _settingsDataPath;

        private void InitializeData()
        {
            if (!File.Exists(_settingsDataPath))
            {
                CreateNewData();
                SaveData();
            }
            else
                LoadData();
        }

        public void CreateNewData()
        {
            SettingsData = new SettingsData();
        }

        public SettingsData GetCurrentData()
        {            
            return SettingsData;
        }

        public void SaveData()
        {
            var dataToWrite = JsonUtility.ToJson(SettingsData);

            using (StreamWriter streamWriter = new StreamWriter(_settingsDataPath))
            {
                streamWriter.Write(dataToWrite);
            }
        }

        public void LoadData()
        {
            string jsonFile;

            using (StreamReader streamReader = new StreamReader(_settingsDataPath))
            {
                jsonFile = streamReader.ReadToEnd();
            }
            
            var dataToLoad = JsonUtility.FromJson<SettingsData>(jsonFile);

            SettingsData = dataToLoad;
        }
    }
}