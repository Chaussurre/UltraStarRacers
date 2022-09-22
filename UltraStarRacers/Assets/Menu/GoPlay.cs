using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class GoPlay : MonoBehaviour
    {
        public int PlayScene;
        
        public void PlayGame()
        {
            SceneManager.LoadScene(PlayScene);
        }
    }
}
