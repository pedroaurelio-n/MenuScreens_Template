using UnityEngine;
using UnityEngine.Audio;
 
namespace PedroAurelio.AudioSystem
{
    [CreateAssetMenu(fileName = "New Audio Clip", menuName = "Audio/Audio Clip")]
    public class AudioClipSO : ScriptableObject
    {
        public AudioClip Clip;
        public bool Loop;
        public AudioMixerGroup MixerGroup;
    }
}