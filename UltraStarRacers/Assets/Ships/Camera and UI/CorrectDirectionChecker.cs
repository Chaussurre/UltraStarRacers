using System;
using System.Collections;
using System.Collections.Generic;
using Map.generation;
using TMPro;
using UnityEngine;

namespace Ship.CameraUI
{
    public class CorrectDirectionChecker : MonoBehaviour
    {
        public TMP_Text Text;

        public PositionInRace PositionInRace;
        private MapTraceGeneration TraceGeneration;

        private void Start()
        {
            TraceGeneration = FindObjectOfType<MapTraceGeneration>();
        }

        void LateUpdate()
        {
            if (PositionInRace.PointIndex >= TraceGeneration.points.Count - 1)
            {
                Text.enabled = false;
                return;
            }
            
            var pos = TraceGeneration.points[PositionInRace.PointIndex];
            var dir = TraceGeneration.points[PositionInRace.PointIndex + 1] - pos;
            Text.enabled = Vector3.Dot(dir.normalized, transform.forward) < -0.1;
        }
    }
}
