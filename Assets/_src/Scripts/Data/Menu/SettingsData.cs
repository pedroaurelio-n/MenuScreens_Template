namespace PedroAurelio.Data
{
    [System.Serializable]
    public class SettingsData
    {
        public FullAudioData AudioData;

        public SettingsData()
        {
            AudioData = new FullAudioData();
        }

        [System.Serializable]
        public class FullAudioData : AudioData
        {

            public float DefaultMaster;
            public float DefaultSfx;
            public float DefaultMusic;
            public float DefaultUI;

            private const float DEFAULT_MASTER = 0.5f;
            private const float DEFAULT_SFX = 1f;
            private const float DEFAULT_MUSIC = 1f;
            private const float DEFAULT_UI = 1f;

            public FullAudioData()
            {
                MasterVolume = DefaultMaster = DEFAULT_MASTER;
                SfxVolume = DefaultSfx = DEFAULT_SFX;
                MusicVolume = DefaultMusic = DEFAULT_MUSIC;
                UIVolume = DefaultUI = DEFAULT_UI;
            }

            public void SetDefaultValues()
            {
                MasterVolume = DEFAULT_MASTER;
                SfxVolume = DEFAULT_SFX;
                MusicVolume = DEFAULT_MUSIC;
                UIVolume = DEFAULT_UI;
            }
        }
    }

    public class AudioData
    {
        public float MasterVolume;
        public float SfxVolume;
        public float MusicVolume;
        public float UIVolume;

        public AudioData()
        {
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