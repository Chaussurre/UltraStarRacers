using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ship.Controls;
using TMPro;
using UnityEngine;

namespace Game.Rules
{
    public class GameStart : MonoBehaviour
    {
        private MouvementControler[] shipsControllers;
        private PlayerInputManager[] shipsInput;
        private List<Camera> shipsCamera = new List<Camera>(2);

        public Camera PreGameCamera;
        public float PreGameTime;
        public float PreGameRotationSpeed;
        public int counter;
        public float TextSizeMin;
        public float TextSizeMax;
        public TMP_Text Text;
        public string StartText;

        //public GameObject Door;
        //float positionStart;
        //public float positionEnd;
        
        IEnumerator Start()
        {
            //positionStart = Door.transform.position.y;
            shipsControllers = FindObjectsOfType<MouvementControler>();
            shipsInput = FindObjectsOfType<PlayerInputManager>();
            foreach (var controller in shipsControllers)
                shipsCamera.Add(controller.GetComponentInChildren<Camera>());

            Text.enabled = false;

            SetShipsEnabled(false);
            SetShipCameraEnabled(false);

            yield return PreGameCameraRotateRoutine();
            
            SetShipCameraEnabled(true);

            yield return ReadyCountdownRoutine();
            
            SetShipsEnabled(true);

            for (float timer = 0; timer < 1; timer += Time.deltaTime)
            {
                Text.fontSize = Mathf.Lerp(TextSizeMin, TextSizeMax, timer);
                yield return null;
            }

            Text.enabled = false;
        }

        private IEnumerator ReadyCountdownRoutine()
        {
            Text.enabled = true;
            for (float timer = 0; timer < 1; timer += Time.deltaTime)
            {
                Text.fontSize = Mathf.Lerp(TextSizeMin, TextSizeMax, timer);
                yield return null;
            }
            for (float timer = 0; timer < counter; timer += Time.deltaTime)
            {
                int counted = Mathf.FloorToInt(timer);
                Text.text = (counter - counted).ToString();
                Text.fontSize = Mathf.Lerp(TextSizeMin, TextSizeMax, timer - counted);
                yield return null;
            }

            Text.text = StartText;
        }

        IEnumerator PreGameCameraRotateRoutine()
        {
            for (float timer = 0; timer < PreGameTime; timer += Time.deltaTime)
            {
                if (InputIsPressed())
                    break;
                transform.Rotate(Vector3.up, PreGameRotationSpeed * Time.deltaTime);
                yield return null;
            }
        }

        bool InputIsPressed()
        {
            foreach (var Inputs in shipsInput)
                if (Inputs.inputs.Brake || Inputs.inputs.Accelerate)
                    return true;
            return false;
        }

        private void SetShipsEnabled(bool value)
        {
            foreach (var controller in shipsControllers)
                controller.enabled = value;
        }
        
        private void SetShipCameraEnabled(bool value)
        {
            PreGameCamera.enabled = !value;
            foreach (var camera in shipsCamera)
                camera.enabled = value;
        }
    }
}
