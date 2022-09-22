using System.Collections;
using System.Collections.Generic;
using Map.generation;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Menu
{
    public class LevelSelectionButton : MonoBehaviour
    {
        public TMP_Text Name;
        public Image BackGround;
        public UnityEvent<LevelDescription> OnSelected;

        private LevelDescription description;
        
        public void SetLevelDescription(LevelDescription desc)
        {
            description = desc;
            Name.text = desc.Name;
            BackGround.color = desc.WallColor;
        }

        public void OnSelect()
        {
            OnSelected?.Invoke(description);
        }
    }
}
