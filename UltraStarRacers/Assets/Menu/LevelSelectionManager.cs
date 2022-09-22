using System.Collections;
using System.Collections.Generic;
using Map.generation;
using TMPro;
using UnityEngine;

namespace UI.Menu
{
    public class LevelSelectionManager : MonoBehaviour
    {
        public TMP_Text LevelName;
        public TMP_Text LevelDescription;

        public void SetLevel(LevelDescription description)
        {
            LevelName.text = description.Name;
            LevelDescription.text = description.Description;
        }
    }
}
