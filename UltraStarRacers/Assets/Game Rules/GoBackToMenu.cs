using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Rules
{
    public class GoBackToMenu : MonoBehaviour
    {
        public int MenuScene;
        public float Delay;

        public void OnEndReached()
        {
            Invoke(nameof(ReturnToMainMenu), Delay);
        }

        void ReturnToMainMenu()
        {
            SceneManager.LoadScene(MenuScene);
        }
    }
}
