using System;
using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Options
{
    public class PauseManager : MonoBehaviour
    {
        public GameObject Options;        
        public int MainMenuScene;
        private bool pause;
        private MouvementController[] Controllers;

        private void Start()
        {
            Controllers = FindObjectsOfType<MouvementController>();
        }

        public void Pause(bool value)
        {
            Time.timeScale = value ? 0 : 1;
            foreach (var controller in Controllers)
                controller.enabled = !value;                
            pause = value;
            Options.SetActive(pause);
        }

        private void Update()
        {
            var keyboard = Keyboard.current;
            if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame)
            {
                Pause(!pause);
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Pause(false);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(MainMenuScene);
            Pause(false);
        }
    }
}
