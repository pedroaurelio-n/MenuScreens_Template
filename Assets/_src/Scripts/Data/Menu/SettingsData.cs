namespace PedroAurelio.Data
{
    [System.Serializable]
    public class SettingsData
    {
        public AudioData AudioData;
        public GraphicsData GraphicsData;

        public SettingsData()
        {
            AudioData = new AudioData();
            GraphicsData = new GraphicsData();
        }
    }

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

    [System.Serializable]
    public class GraphicsData
    {
        public int ResolutionOption;
        public int ResolutionWidth;
        public int ResolutionHeight;
        public int Quality;
        public bool Fullscreen;

        private const int DEFAULT_RESOPT = 0;
        private const int DEFAULT_WIDTH = 1280;
        private const int DEFAULT_HEIGHT = 720;
        private const int DEFAULT_QUALITY = 0;
        private const bool DEFAULT_FULLSCREEN = false;

        public GraphicsData()
        {
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            ResolutionOption = DEFAULT_RESOPT;
            ResolutionWidth = DEFAULT_WIDTH;
            ResolutionHeight = DEFAULT_HEIGHT;
            Quality = DEFAULT_QUALITY;
            Fullscreen = DEFAULT_FULLSCREEN;
        }

        public GraphicsData(int resolutionOption, int width, int height, int quality, bool fullscreen)
        {
            ResolutionOption = resolutionOption;
            ResolutionWidth = width;
            ResolutionHeight = height;
            Quality = quality;
            Fullscreen = fullscreen;
        }
    }
}