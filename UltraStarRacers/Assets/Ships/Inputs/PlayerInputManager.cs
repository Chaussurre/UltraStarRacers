using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship.Controls
{
    public class PlayerInputManager : InputManager
    {
        protected override InputsState GetInputs()
        {
            return new InputsState()
            {
                accelerate = true
            };
        }
    }
}
