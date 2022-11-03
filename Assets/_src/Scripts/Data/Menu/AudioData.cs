namespace PedroAurelio.Data
{
    [System.Serializable]
    public class AudioData
    {
        public float MasterVolume;
        public float SfxVolume;
        public float MusicVolume;
        public float UIVolume;

        private const float DEFAULT_MASTER = 0.5f;
        private const float DEFAULT_SFX = 1f;
        private const float DEFAULT_MUSIC = 1f;
        private const float DEFAULT_UI = 1f;

        public AudioData()
        {
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            MasterVolume = DEFAULT_MASTER;
            SfxVolume = DEFAULT_SFX;
            MusicVolume = DEFAULT_MUSIC;
            UIVolume = DEFAULT_UI;
        }

        public AudioData(float master, float sfx, float music, float ui)
        {
            MasterVolume = master;
            SfxVolume = sfx;
            MusicVolume = music;
            UIVolume = ui;
        }
    }
}