using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using UnityEngine;

namespace ship.CameraUI
{
    public class SpeedMeter : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public ShipsStats stats;
        public Transform cursor;

        void Update()
        {
            var speed = Vector3.Project(rigidbody.velocity, rigidbody.transform.forward).magnitude; 
            cursor.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(90, -90, speed / stats.SpeedMax));
        }
    }
}
