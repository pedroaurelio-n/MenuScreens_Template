using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
namespace PedroAurelio.SOEventSystem
{
    public abstract class BaseEventListener : MonoBehaviour
    {
        [SerializeField] private GameEventSO gameEvent;
        [SerializeField] protected float delay;
        [SerializeField] protected bool isOneShot;

        protected bool _WasRaised = false;

        public void OnEventRaised()
        {
            if (_WasRaised)
                return;

            if (delay <= 0)
                InvokeEvent();
            else
                StartCoroutine(OnEventDelayedCoroutine());
        }

        private IEnumerator OnEventDelayedCoroutine()
        {
            yield return new WaitForSeconds(delay);
            InvokeEvent();
        }

        protected virtual void InvokeEvent()
        {
            if (isOneShot)
                _WasRaised = true;
        }

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }
    }
}