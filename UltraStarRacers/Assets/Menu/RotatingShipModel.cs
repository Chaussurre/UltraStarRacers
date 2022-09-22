using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Menu
{
    public class RotatingShipModel : MonoBehaviour
    {
        public float RotatingSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.up, RotatingSpeed * Time.deltaTime);
        }
    }
}
