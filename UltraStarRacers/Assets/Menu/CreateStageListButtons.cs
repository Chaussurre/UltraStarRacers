using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Map.generation;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Menu
{
    public class CreateStageListButtons : MonoBehaviour
    {
        public List<LevelDescription> Levels;
        public List<LevelDescription> JokeLevels;
        public LevelSelectionButton ButtonPrefab;

         List<GameObject> Childs = new List<GameObject>();

        public UnityEvent<LevelDescription> OnLevelSelected;
        public LevelDescription defaultLevel;

        private void OnEnable()
        {
            foreach (var level in Levels)
            {
                var button = Instantiate(ButtonPrefab, transform);
                button.SetLevelDescription(level);
                button.transform.SetAsLastSibling();
                button.OnSelected.AddListener(SelectLevel);
                
                Childs.Add(button.gameObject);
            }

            if (PlayerPrefs.GetInt("Joke Levels", 0) == 1)
            {
                foreach (var level in JokeLevels)
                {
                    var button = Instantiate(ButtonPrefab, transform);
                    button.SetLevelDescription(level);
                    button.transform.SetAsLastSibling();
                    button.OnSelected.AddListener(SelectLevel);
                
                    Childs.Add(button.gameObject);
                }   
            }

            OnLevelSelected.AddListener(LevelSelectionManager.Instance.SelectLevel);
            OnLevelSelected?.Invoke(defaultLevel);
        }

        private void OnDisable()
        {
            Childs.ForEach(Destroy);
            Childs.Clear();
            OnLevelSelected.RemoveListener(LevelSelectionManager.Instance.SelectLevel);
        }

        void SelectLevel(LevelDescription level)
        {
            OnLevelSelected?.Invoke(level);
        }
    }
}
