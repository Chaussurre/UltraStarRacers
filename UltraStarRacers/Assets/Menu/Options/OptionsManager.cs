using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Options
{
    public class OptionsManager : MonoBehaviour
    {
        public static OptionsManager Instance;

        public bool AllowGrass;
        public bool AllowShadows;
        public bool JokeLevels;

        public UnityEvent OnOptionsChange;
        
        void Start()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
            InnitOptions();
        }

        public void InnitOptions()
        {
            AllowGrass = PlayerPrefs.GetInt("Allow Grass", 1) == 1;
            AllowShadows = PlayerPrefs.GetInt("Allow Shadows", 1) == 1;
            JokeLevels = PlayerPrefs.GetInt("Joke Levels", 0) == 1;

            QualitySettings.shadows = AllowShadows ? ShadowQuality.All : ShadowQuality.Disable;
            OnOptionsChange?.Invoke();
        }
    }
}
