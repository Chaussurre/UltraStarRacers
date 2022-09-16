using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

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
            public float Rotate;
            public bool accelerate;
            public bool brake;
            public ActionButtonState Action1;
            public ActionButtonState Action2;
            public ActionButtonState Action3;
        }

        public InputsState inputs;
        
        void Update()
        {
            inputs = GetInputs();
        }

        protected abstract InputsState GetInputs();
    }
}