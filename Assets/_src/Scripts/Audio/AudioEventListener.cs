using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.SOEventSystem
{
    public class AudioEventListener : BaseEventListener
    {
        public delegate void PlayAudio(AudioClipSO clipSO, Vector3 position, float delay);
        public static event PlayAudio onPlayAudio;

        public void OnEventRaised(AudioClipSO clipSO, Vector3 position)
        {
            if (_WasRaised)
                return;

            onPlayAudio?.Invoke(clipSO, position, delay);
            
            if (isOneShot)
                _WasRaised = true;
        }
    }
}