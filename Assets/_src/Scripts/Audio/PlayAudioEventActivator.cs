using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.SOEventSystem
{
    public class PlayAudioEventActivator : BaseEventActivator
    {
        [SerializeField] private AudioClipSO clipSO;
        [SerializeField] private bool playOnStart;

        private AudioEventSO _audioEvent;

        private void Awake()
        {
            if (gameEvent is not AudioEventSO)
            {
                Debug.LogWarning($"Game Event tied to object is not an AudioEvent");
                return;
            }

            _audioEvent = gameEvent as AudioEventSO;
        }

        private void Start()
        {
            if (playOnStart)
                _audioEvent.RaiseEvent(clipSO, transform.position);
        }

        public void PlayAudio()
        {
            _audioEvent.RaiseEvent(clipSO, transform.position);            
        }
    }
}