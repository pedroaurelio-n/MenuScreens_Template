using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.SOEventSystem
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Events/Game Event")]
    public class GameEventSO : ScriptableObject
    {
        protected List<BaseEventListener> listeners = new List<BaseEventListener>();

        public void RaiseEvent()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(BaseEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(BaseEventListener listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}