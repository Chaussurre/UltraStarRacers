using System;
using System.Collections;
using System.Collections.Generic;
using Map.generation;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Menu
{
    public class CreateStageListButtons : MonoBehaviour
    {
        public List<LevelDescription> Levels;
        public LevelSelectionButton ButtonPrefab;

        public UnityEvent<LevelDescription> OnLevelSelected;
        public LevelDescription defaultLevel;

        private void Start()
        {
            foreach (var level in Levels)
            {
                var button = Instantiate(ButtonPrefab, transform);
                button.SetLevelDescription(level);
                button.transform.SetAsLastSibling();
                button.OnSelected.AddListener(SelectLevel);
            }
            
            OnLevelSelected?.Invoke(defaultLevel);
        }

        void SelectLevel(LevelDescription level)
        {
            OnLevelSelected?.Invoke(level);
        }
    }
}
