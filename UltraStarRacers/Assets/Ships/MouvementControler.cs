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
        
        [SerializeField] private ShipsStats Stats;
        
        void Start()
        {
            RB = GetComponentInChildren<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var inputs = Inputs.inputs;
            if (inputs.Rotate != 0)
                Rotate(inputs.Rotate < 0);
            
            if (!inputs.Accelerate && !inputs.Brake)
                NaturalSlow();
            else
            {
                var forwardSpeed = Vector3.Project(RB.velocity, transform.forward).magnitude;
                if (inputs.Brake)
                    Brake();
                else if (forwardSpeed < Stats.SpeedMax)
                    NaturalSlow();
                else
                    NaturalSideSlow();
                
                if (forwardSpeed < Stats.SpeedMax && inputs.Accelerate)
                    Accelerate();
            }
        }

        Vector3 SlowSpeed(Vector3 speed, float SlowRate)
        {
            return speed * Mathf.Clamp01(1 - SlowRate * Time.fixedDeltaTime);
        }
        
        void NaturalSlow()
        {
            RB.velocity = SlowSpeed(RB.velocity, Stats.SlowRate);
        }

        void NaturalSideSlow()
        {
            var forward = Vector3.Project(RB.velocity, transform.forward);
            var sideSpeed = RB.velocity - forward;
            sideSpeed = SlowSpeed(sideSpeed, Stats.SlowRate);
            RB.velocity = sideSpeed + forward;
        }

        void Accelerate()
        {
            RB.velocity += transform.forward * (Stats.Acceleration * Time.fixedDeltaTime);
        }

        void Brake()
        {
            RB.velocity = SlowSpeed(RB.velocity, Stats.BrakeRate);
        }

        void Rotate(bool rotateLeft)
        {
            Quaternion destination = Quaternion.LookRotation(rotateLeft ? -transform.right : transform.right,
                transform.up);
            RB.MoveRotation(Quaternion.RotateTowards(RB.rotation, destination, 
                Stats.RotateSpeed * Time.fixedDeltaTime));
        }
    }
}