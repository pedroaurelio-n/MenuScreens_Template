using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
namespace PedroAurelio.SOEventSystem
{
    public class BaseEventActivator : MonoBehaviour
    {
        [SerializeField] protected GameEventSO gameEvent;
        [SerializeField] protected int itemsNeeded;
        [SerializeField] protected bool willReduceItems;
        [SerializeField] protected UnityEvent onFail;

        protected bool _WasSuccesful;
        private int _itemCount = 99;

        public void Raise()
        {
            if (_WasSuccesful || _itemCount >= itemsNeeded)
            {
                gameEvent.RaiseEvent();

                if (willReduceItems && !_WasSuccesful)
                    _itemCount -= itemsNeeded;
                    
                _WasSuccesful = true;
            }
            else
            {
                _WasSuccesful = false;
                onFail?.Invoke();
            }
        }
    }
}