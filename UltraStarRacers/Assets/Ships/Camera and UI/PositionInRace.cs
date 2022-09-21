using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Map.generation;
using TMPro;
using UnityEngine;

namespace Ship.CameraUI
{
    public class PositionInRace : MonoBehaviour
    {
        public float DistanceFromPoint { get; private set; }

        private MapTraceGeneration TraceGeneration;
        public int PointIndex { get; private set; }

        public TMP_Text Text;
        private PositionInRace[] others;
        public string[] rankTexts;
        
        private void Start()
        {
            TraceGeneration = FindObjectOfType<MapTraceGeneration>();
            others = FindObjectsOfType<PositionInRace>();
        }

        void Update()
        {
            int minIndex = 0;
            float minDist = float.MaxValue;
            for (int i = 0; i < TraceGeneration.points.Count; i++)
            {
                var dist = (TraceGeneration.points[i] - transform.position).sqrMagnitude;
                if (minDist > dist)
                {
                    minIndex = i;
                    minDist = dist;
                }
            }

            PointIndex = minIndex;
            DistanceFromPoint = 0;
            if (PointIndex < TraceGeneration.points.Count - 1)
            {
                var posPoint = TraceGeneration.points[PointIndex];
                var dir = TraceGeneration.points[PointIndex + 1] - posPoint;
                DistanceFromPoint = Vector3.Dot(transform.position - posPoint, dir.normalized);
            }
        }

        private void LateUpdate()
        {
            int rank = 0;
            foreach (var other in others)
            {
                if (other.PointIndex > PointIndex ||
                    (other.PointIndex == PointIndex && other.DistanceFromPoint > DistanceFromPoint))
                    rank++;
            }

            Text.text = rankTexts[rank];
        }
    }
}
