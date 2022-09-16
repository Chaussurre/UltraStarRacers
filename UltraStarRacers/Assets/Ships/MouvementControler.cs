using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship.Controls
{
    public class MouvementControler : MonoBehaviour
    {
        [SerializeField] private InputManager Inputs;
        private Rigidbody RB;
        
        void Start()
        {
            RB = GetComponentInChildren<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (Inputs.inputs.Accelerate)
            {
                RB.AddForce(transform.forward);
            }
        }
    }
}