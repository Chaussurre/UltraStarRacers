using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

namespace Ship.Controls
{
    public abstract class InputManager : MonoBehaviour
    {
        public enum ActionButtonState
        {
            NotPressed, Released, Pressed, Held
        }
        
        [System.Serializable]
        public struct InputsState
        {
            public double Rotate;
            public bool Accelerate;
            public bool Brake;
            public ActionButtonState Action1;
            public ActionButtonState Action2;
            public ActionButtonState Action3;
        }

        public InputsState inputs;
    }
}