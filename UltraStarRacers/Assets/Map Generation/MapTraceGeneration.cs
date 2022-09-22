using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

namespace Map.generation
{
    public class MapTraceGeneration : MonoBehaviour
    {
        public readonly List<Vector3> points = new();

        [SerializeField] private GameObject EndArena;
        [SerializeField] private MeshCreation MeshCreation;
        [SerializeField] private MapGrassManager GrassManager;

        [SerializeField] private float TotalDistance;

        [SerializeField] private MapZone firstZone;

        public LevelDescription levelDescription;
        
        private void Start()
        {
            levelDescription = FindObjectOfType<LevelSelectionManager>().selected;
            TotalDistance = levelDescription.Distance;
            GenerateTrace();
        }

        [ContextMenu("Generate map")]
        private void GenerateTrace()
        {
            points.Clear();

            float distance = 0;
            
            float angle = 0;
            var position = Vector3.zero;
            int index = 0;
            
            GenerateZone(firstZone, ref angle, ref position, ref index);
            
            while (distance < TotalDistance)
            {
                var zone = ChooseRandomZone();
                distance += zone.distanceBetweenPoints * zone.PointCount;
                GenerateZone(zone, ref angle, ref position, ref index);
            }
            GenerateZone(firstZone, ref angle, ref position, ref index);
            MeshCreation.FinishMesh(points, firstZone, levelDescription.WallColor);
            
            var direction = Quaternion.AngleAxis(angle, Vector3.up) *  Vector3.forward;
            EndArena.transform.SetPositionAndRotation(points[^1], Quaternion.LookRotation(-direction));
        }

        MapZone ChooseRandomZone()
        {
            var Zones = levelDescription.Zones;
            float totalWeight = Zones.Sum(x => x.weight);
            float weightSelector = Random.Range(0, totalWeight);
            int i = 0;
            while (weightSelector > Zones[i].weight)
            {
                i++;
                weightSelector -= Zones[i].weight;
            }

            if (i >= Zones.Count)
                i = Zones.Count - 1;

            return Zones[i].zone;
        }
        
        private void GenerateZone(MapZone zone, ref float angle, ref Vector3 position, ref int index)
        {
            float angleDelta = 0;
            int ALock = 0;
            
            for (int i = 0; i < zone.PointCount; i++)
            {
                points.Add(position);

                if (ALock <= 0)
                {
                    angleDelta = UnityEngine.Random.Range(-zone.AngleBetweenPoints, zone.AngleBetweenPoints);
                    ALock = UnityEngine.Random.Range(zone.AngleLockMin, zone.AngleLockMax);
                }
                else ALock--;

                angle += angleDelta;

                if (angle > 90 || angle < -90)
                {
                    angle = Mathf.Clamp(angle, -90, 90);
                    ALock = 0;
                }

                var direction = Quaternion.AngleAxis(angle, Vector3.up) *  Vector3.forward;
                position += direction * zone.distanceBetweenPoints;
            }

            MeshCreation.CreateMesh(points, zone, index);
            GrassManager.GenerateGrass(points, zone, index);
            index += zone.PointCount;
        }
    }
}
