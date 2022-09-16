using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ship.Controls
{
    
    public class PlayerInputManager : InputManager
    {
        private PlayerInput playerInput;

        private void Start()
        {
            playerInput = new PlayerInput();
            playerInput.asset.Enable();
        }

        private void Update()
        {
            
            inputs.Rotate = playerInput.Player.Rotate.ReadValue<Vector2>().x;
            inputs.Accelerate = playerInput.Player.Accelerate.IsPressed();
            inputs.Brake = playerInput.Player.Brake.IsPressed();
            inputs.Action1 = GetInputState(playerInput.Player.Action1);
            inputs.Action2 = GetInputState(playerInput.Player.Action2);
            inputs.Action3 = GetInputState(playerInput.Player.Action3);
        }

        private ActionButtonState GetInputState(InputAction action)
        {
            if (action.WasPressedThisFrame())
                return ActionButtonState.Pressed;
            if (action.IsPressed())
                return ActionButtonState.Held;
            if (action.WasReleasedThisFrame())
                return ActionButtonState.Released;
            return ActionButtonState.NotPressed;
        }

        //public void OnRotate(InputAction.CallbackContext context)
       //{
       //    inputs.Rotate = context.action.ReadValue<Vector2>().x;
       //}
       //
       //public void OnAccelerate(InputAction.CallbackContext context)
       //{
       //    inputs.accelerate = context.action.IsPressed();
       //}
       //
       //public void OnBrake(InputAction.CallbackContext context)
       //{
       //    inputs.brake = context.action.IsPressed();
       //}
       //public void OnAction1(InputAction.CallbackContext context)
       //{
       //    if (context.action.WasPressedThisFrame())
       //        inputs.Action1 = ActionButtonState.Pressed;
       //    else if (context.action.IsPressed())
       //        inputs.Action1 = ActionButtonState.Held;
       //    else if (context.action.WasReleasedThisFrame())
       //        inputs.Action1 = ActionButtonState.Released;
       //}
       //public void OnAction2(InputAction.CallbackContext context)
       //{
       //    if (context.action.WasPressedThisFrame())
       //        inputs.Action2 = ActionButtonState.Pressed;
       //    else if (context.action.IsPressed())
       //        inputs.Action2 = ActionButtonState.Held;
       //    else if (context.action.WasReleasedThisFrame())
       //        inputs.Action2 = ActionButtonState.Released;
       //}
       //
       //public void OnAction3(InputAction.CallbackContext context)
       //{
       //    if (context.action.WasPressedThisFrame())
       //        inputs.Action3 = ActionButtonState.Pressed;
       //    else if (context.action.IsPressed())
       //        inputs.Action3 = ActionButtonState.Held;
       //    else if (context.action.WasReleasedThisFrame())
       //        inputs.Action3 = ActionButtonState.Released;
       //}

    }
}
