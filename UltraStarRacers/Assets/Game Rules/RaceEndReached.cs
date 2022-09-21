using System;
using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Rules
{
    public class RaceEndReached : MonoBehaviour
    {
        public UnityEvent<MouvementController> OnEndReached;

        private bool endReached = false;
        private void OnTriggerEnter(Collider other)
        {
            if (endReached)
                return;
            
            if (other.attachedRigidbody != null)
            {
                var controller = other.attachedRigidbody.GetComponent<MouvementController>();
                if (controller != null)
                {
                    endReached = true;
                    OnEndReached?.Invoke(controller);
                }
            }
        }
        
        
    }
}
