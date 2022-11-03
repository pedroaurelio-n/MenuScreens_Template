namespace PedroAurelio.Data
{
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