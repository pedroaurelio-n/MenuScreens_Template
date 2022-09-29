using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PedroAurelio.MenuScreens
{
    [RequireComponent(typeof(Slider))]
    public class SliderUpdateText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private string stringFormat = "00";
        [SerializeField] private int multiplyValueBy = 100;

        public void UpdateText(float value)
        {
            var multipliedValue = value * multiplyValueBy;
            valueText.text = multipliedValue.ToString(stringFormat);
        }
    }
}