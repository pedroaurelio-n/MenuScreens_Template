namespace PedroAurelio.Data
{
    [System.Serializable]
    public class SettingsData
    {
        public AudioData AudioData;
        public GraphicsData GraphicsData;
        public GameplayData GameplayData;

        public SettingsData()
        {
            AudioData = new AudioData();
            GraphicsData = new GraphicsData();
            GameplayData = new GameplayData();
        }
    }
}