using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Ship.Controls;
using UnityEngine;

namespace Ship.CameraUI
{
    public class CameraController3rdPerson : MonoBehaviour
    {
        public InputManager Inputs;
        public ShipsStats Stats;
        public Rigidbody Rigidbody;
        
        public Transform MaximumCameraPos;
        public Camera Camera;

        [Tooltip("The maximum angle the camera can take when turning the ship")] [SerializeField]
        private float RotationAngleMax;

        [SerializeField] private float RotationSpeed;

        private void FixedUpdate()
        {
            Rotate();
            Zoom();
        }

        private void Zoom()
        {
            var forward = Vector3.Project(Rigidbody.velocity, Rigidbody.transform.forward);
            float lerp = forward.magnitude / Stats.SpeedMax;

            Camera.transform.localPosition = Vector3.Lerp(Vector3.zero, MaximumCameraPos.localPosition, lerp);
            Camera.transform.localRotation = Quaternion.Lerp(Quaternion.identity, MaximumCameraPos.localRotation, lerp);
        }

        void Rotate()
        {
            var TargetRotation = Quaternion.AngleAxis(RotationAngleMax * Inputs.inputs.Rotate, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, TargetRotation,
                RotationSpeed * Time.deltaTime);
        }
    }
}
