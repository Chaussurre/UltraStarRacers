using System;
using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Menu
{
    public class ShowDevice : MonoBehaviour
    {
        public TMP_Text Text;

        public bool Top;
        //public Button RemovePlayer;
        string DefaultMessage;

        private void Start()
        {
            DefaultMessage = Text.text;
            //RemovePlayer.gameObject.SetActive(false);
            if (Top)
                DeviceManager.Instance.OnTopPlayer.AddListener(OnDeviceConnected);
            else
                DeviceManager.Instance.OnBottomPlayer.AddListener(OnDeviceConnected);
        }

        private void OnDestroy()
        {
            if (Top)
                DeviceManager.Instance.OnTopPlayer.RemoveListener(OnDeviceConnected);
            else
                DeviceManager.Instance.OnBottomPlayer.RemoveListener(OnDeviceConnected);
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
