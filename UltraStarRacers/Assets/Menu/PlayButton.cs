using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Menu
{
    public class PlayButton : MonoBehaviour
    {
        public Button Button;
        
        private bool TopReady;
        private bool BottomReady;

        private void Start()
        {
            CheckReady();
        }

        public void SetTopReady(PlayerInput input)
        {
            TopReady = input != null;
            CheckReady();
        }
        
        public void SetBottomReady(PlayerInput input)
        {
            BottomReady = input != null;
            CheckReady();
        }

        void CheckReady()
        {
            Button.gameObject.SetActive(TopReady && BottomReady);
        }
    }
}
