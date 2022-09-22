using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.Menu
{
    public class ListenToDevices : MonoBehaviour
    {
        public PlayerInputManager InputManager;

        private void OnEnable() => InputManager.EnableJoining();
        private void OnDisable() => InputManager.DisableJoining();
    }
}
