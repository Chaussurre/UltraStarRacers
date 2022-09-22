using System;
using System.Collections;
using System.Collections.Generic;
using Options;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map.generation
{
    public class MapGrassManager : MonoBehaviour
    {
        [SerializeField] private GameObject GrassPrefab;

        [SerializeField] private float Margin;
        [SerializeField] private float distanceStep;

        private void Start()
        {
            OptionsManager.Instance.OnOptionsChange.AddListener(CheckIfGrassAllowed);
            gameObject.SetActive(OptionsManager.Instance.AllowGrass);
        }

        private void CheckIfGrassAllowed()
        {
            gameObject.SetActive(OptionsManager.Instance.AllowGrass);
        }

        private void OnDestroy()
        {
            OptionsManager.Instance.OnOptionsChange.RemoveListener(CheckIfGrassAllowed);
        }


        public void GenerateGrass(List<Vector3> points, MapZone zone, int StartIndex)
        {
            var radius = zone.PathWidth - Margin;

            float distance = 0;
            for (int i = StartIndex; i < points.Count - 2; i = GetIndex(StartIndex, zone, distance))
            {
                var pos = GetPos(distance, points, StartIndex, i, zone);
                for (int j = 0; j < zone.GrassPerStep; j++)
                {
                    var dir = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.forward;
                    var gPos = pos + dir * Random.Range(0, radius);
                    var gRot = Quaternion.Euler(0, Random.Range(0, 360), 0);
                    Instantiate(GrassPrefab, gPos, gRot, transform);
                }
                distance += distanceStep;
            }
        }

        int GetIndex(int startIndex, MapZone zone, float distance)
        {
            return Mathf.FloorToInt(distance / zone.distanceBetweenPoints) + startIndex;
        }

        Vector3 GetPos(float distance, List<Vector3> points, int startIndex, int index, MapZone zone)
        {
            var distanceToNext = distance - (index - startIndex) * zone.distanceBetweenPoints;
            return Vector3.Lerp(points[index], points[index + 1], distanceToNext / zone.distanceBetweenPoints);
        }
    }
}
