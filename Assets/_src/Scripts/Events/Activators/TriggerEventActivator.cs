using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.SOEventSystem
{
    public class TriggerEventActivator : BaseEventActivator
    {
        [SerializeField] private LayerMask layerMask;

        private void OnTriggerEnter(Collider other)
        {
            if ((1 << other.gameObject.layer & layerMask) != 0)
                Raise();
        }
    }
}