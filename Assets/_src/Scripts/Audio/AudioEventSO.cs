using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
namespace PedroAurelio.SOEventSystem
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Events/Audio Event")]
    public class AudioEventSO : GameEventSO
    {
        public UnityAction<AudioClipSO, Vector3> OnRaiseAudio;

        public void RaiseEvent(AudioClipSO clipSO, Vector3 position)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                var listener = listeners[i] as AudioEventListener;
                listener.OnEventRaised(clipSO, position);
            }
        }
    }
}