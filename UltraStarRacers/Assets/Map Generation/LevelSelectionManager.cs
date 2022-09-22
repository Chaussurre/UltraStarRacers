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
        
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void SelectLevel(LevelDescription description)
        {
            selected = description;
        }
    }
}
