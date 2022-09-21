using System;
using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using TMPro;
using UnityEngine;

namespace ship.CameraUI
{
    public class VicotryTextManager : MonoBehaviour
    {
        public string WinningText;
        public string LoosingText;

        public TMP_Text Text;

        public MouvementController controller;

        public float fontMin;
        public float fontMax;
        public float LoopTime;

        private float timer;
        private void Start()
        {
            Text.enabled = false;
        }

        public void SetVictory(MouvementController winningController)
        {
            Text.text = winningController == controller ? WinningText : LoosingText;
            Text.enabled = true;
        }

        private void Update()
        {
            if (!Text.enabled)
                return;
            
            timer += Time.deltaTime;

            if (timer < LoopTime)
                Text.fontSize = Mathf.Lerp(fontMin, fontMax, timer / LoopTime);
            else if (timer < 2 * LoopTime)
                Text.fontSize = Mathf.Lerp(fontMin, fontMax, (2 * LoopTime - timer) / LoopTime);
            else
                timer -= LoopTime * 2;
        }
    }
}
