using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Options
{
    public class ToggleOption : MonoBehaviour
    {
        public Toggle Toggle;
        public string OptionPrefsName;
        public int DefaultOptionValue;
        
        private void Start()
        {
            Toggle.SetIsOnWithoutNotify(PlayerPrefs.GetInt(OptionPrefsName, DefaultOptionValue) == 1);
        }

        public void OnToggle(bool value)
        {
            PlayerPrefs.SetInt(OptionPrefsName, value ? 1 : 0);
            OptionsManager.Instance.InnitOptions();
        }
    }
}
