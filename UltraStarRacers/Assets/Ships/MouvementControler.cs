using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship.Controls
{
    public class MouvementControler : MonoBehaviour
    {
        private InputManager Inputs;
        private Rigidbody RB;
        
        void Start()
        {
            Inputs = GetComponent<InputManager>();
            RB = GetComponentInChildren<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (Inputs.inputs.accelerate)
            {
                RB.AddForce(transform.forward);
            }
        }
    }
}