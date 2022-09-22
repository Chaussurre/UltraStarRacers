using System.Collections;
using System.Collections.Generic;
using Map.generation;
using UnityEngine;
using UnityEngine.UI;

namespace Map.generation
{
    public class LevelSelectionManager : MonoBehaviour
    {
        [HideInInspector] public LevelDescription selected;

        public static LevelSelectionManager Instance;
        
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void SelectLevel(LevelDescription description)
        {
            selected = description;
        }
    }
}
