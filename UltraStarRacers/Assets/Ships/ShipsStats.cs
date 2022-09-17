using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship.Controls
{
    [Serializable]
    public struct ShipsStats
    {
        [Tooltip("In unit per seconds")]
        public float SpeedMax;
        [Tooltip("In unit per seconds²")]
        public float Acceleration;
        public float SlowRate;
        public float BrakeRate;
        [Tooltip("In degrees per seconds")] 
        public float RotateSpeed;
    }
}
