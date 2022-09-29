using UnityEngine;
using UnityEngine.Audio;
 
namespace PedroAurelio.SOEventSystem
{
    [CreateAssetMenu(fileName = "New Audio Clip", menuName = "Audio/Audio Clip")]
    public class AudioClipSO : ScriptableObject
    {
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;
    }
}