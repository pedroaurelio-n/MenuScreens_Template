using UnityEngine;
using TMPro;
 
namespace PedroAurelio.MenuScreens
{
    public class TestScreenSettings : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resolution;
        [SerializeField] private TextMeshProUGUI fullscreen;

        #if UNITY_EDITOR
        private void Awake()
        {
            gameObject.SetActive(false);
        }
        #endif

        #if !UNITY_EDITOR
        private void Update()
        {
            resolution.text = $"resolution: {Screen.width}x{Screen.height} - {Screen.currentResolution.refreshRate}";
            fullscreen.text = $"fullscreen: {Screen.fullScreen.ToString()}";
        }
        #endif
    }
}