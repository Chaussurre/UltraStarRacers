using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace Map.generation
{
    public class MapTraceGeneration : MonoBehaviour
    {
        private List<Vector3> points = new();

        [SerializeField] private int PointCount;
        [SerializeField] private float distanceBetweenPoints;
        [SerializeField] private float AngleBetweenPoints;
        [SerializeField] private int AngleLockMin;
        [SerializeField] private int AngleLockMax;
        [SerializeField] private float PathWidth;

        [SerializeField] private MeshCreation MeshCreation;
        

        public bool generated;

        private void Update()
        {
            if(!generated)
               GenerateTrace(); 
        }

        private void GenerateTrace()
        {
            points.Clear();
            if (!CheckValidInfos())
            {
                Debug.LogError("Map generation infos can intersect");
                return;
            }

            generated = true;

            float angle = 0;
            float angleDelta = 0;
            var position = Vector3.zero;
            int ALock = 0;
            
            for (int i = 0; i < PointCount; i++)
            {
                points.Add(position);

                if (ALock <= 0)
                {
                    angleDelta = UnityEngine.Random.Range(-AngleBetweenPoints, AngleBetweenPoints);
                    ALock = UnityEngine.Random.Range(AngleLockMin, AngleLockMax);
                }
                else ALock--;

                angle += angleDelta;

                if (angle > 90 || angle < -90)
                {
                    angle = Mathf.Clamp(angle, -90, 90);
                    ALock = 0;
                }

                var direction = Quaternion.AngleAxis(angle, Vector3.up) *  Vector3.forward;
                position += direction * distanceBetweenPoints;
            }

            MeshCreation.CreateGround(points, PathWidth);
        }

        private bool CheckValidInfos()
        {
            float maxAngle = 90 - Mathf.Acos(distanceBetweenPoints / (2 * PathWidth)) * Mathf.Rad2Deg;
            Debug.Log($"Max Angle : {maxAngle}");
            return AngleBetweenPoints < maxAngle ;
        }


        public List<Vector3> GetPoints()
        {
            return points;
        }
    }
}
