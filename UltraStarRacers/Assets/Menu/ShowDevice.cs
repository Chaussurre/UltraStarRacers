using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Menu
{
    public class ShowDevice : MonoBehaviour
    {
        public TMP_Text Text;
        //public Button RemovePlayer;
        string DefaultMessage;

        private void Start()
        {
            DefaultMessage = Text.text;
            //RemovePlayer.gameObject.SetActive(false);
        }

        public void OnDeviceConnected(PlayerInput input)
        {
            if (input == null)
                Text.text = DefaultMessage;
            else
                Text.text = input.currentControlScheme;
            
            //RemovePlayer.gameObject.SetActive(input != null);
        }
    }
}
