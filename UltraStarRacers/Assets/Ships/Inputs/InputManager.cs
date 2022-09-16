using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

namespace Ship.Controls
{
    public abstract class InputManager : MonoBehaviour
    {
        [System.Serializable]
        public struct InputsState
        {
            public double Rotate;
            public bool Accelerate;
            public bool Brake;
            public bool Action1;
            public bool Action2;
            public bool Action3;
        }

        public InputsState inputs;
    }
}