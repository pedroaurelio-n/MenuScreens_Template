namespace PedroAurelio.Data
{
    [System.Serializable]
    public class GameplayData
    {
        public bool InvertY;
        public bool ShowFps;

        private const bool DEFAULT_INVERTY = false;
        private const bool DEFAULT_SHOWFPS = false;

        public GameplayData()
        {
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            InvertY = DEFAULT_INVERTY;
            ShowFps = DEFAULT_SHOWFPS;
        }

        public GameplayData(bool invertY, bool showFps)
        {
            InvertY = invertY;
            ShowFps = showFps;
        }
    }
}