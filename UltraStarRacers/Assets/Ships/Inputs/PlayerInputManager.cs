using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ship.Controls
{

    public class PlayerInputManager : InputManager
    {
        public PlayerInput playerInput;

        public void OnRotate(InputAction.CallbackContext context)
        {
            inputs.Rotate = context.action.ReadValue<float>();
        }

        public void OnAccelerate(InputAction.CallbackContext context)
        {
            inputs.Accelerate = context.action.IsPressed();
        }

        public void OnBrake(InputAction.CallbackContext context)
        {
            inputs.Brake = context.action.IsPressed();
        }

        public void OnAction1(InputAction.CallbackContext context)
        {
            inputs.Action1 = context.action.IsPressed();
        }

        public void OnAction2(InputAction.CallbackContext context)
        {
            inputs.Action2 = context.action.IsPressed();
        }

        public void OnAction3(InputAction.CallbackContext context)
        {
            inputs.Action3 = context.action.IsPressed();
        }
    }
}
