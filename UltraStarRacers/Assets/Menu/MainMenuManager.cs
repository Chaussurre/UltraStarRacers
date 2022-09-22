using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Menu
{
    public class MainMenuManager : MonoBehaviour
    {
        public List<GameObject> Menus;

        public void GoToMenu(GameObject Menu)
        {
            Menus.ForEach(x => x.SetActive(x == Menu));
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
