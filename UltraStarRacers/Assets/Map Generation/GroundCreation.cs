using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.generation
{
    public class GroundCreation : MonoBehaviour
    {
        public MapTraceGeneration MapTrace;

        public MeshFilter MeshFilter;
        private Mesh mesh;
        [SerializeField] private float Width;

        private List<Vector3> MeshPoints = new List<Vector3>();
        private List<int> MeshTriangles = new List<int>();
        
        private void Start()
        {
            mesh = new Mesh();
            MeshFilter.mesh = mesh;
        }

        private void Update()
        {            
            CreateGround();
        }

        private void CreateGround()
        {
            var points = MapTrace.GetPoints();
            
            if (points.Count <= 2)
                return;

            MeshPoints.Clear();
            MeshTriangles.Clear();
            mesh.Clear();

            CreatePairPoints(points[0], (points[1] - points[0]).normalized);
            for (int i = 1; i < points.Count - 1; i++)
            {
                CreatePairPoints(points[i], (points[i + 1] - points[i - 1]).normalized);
            }
            CreatePairPoints(points[^1], (points[^1] - points[^2]).normalized, false);

            mesh.vertices = MeshPoints.ToArray();
            mesh.triangles = MeshTriangles.ToArray();
        }

        void CreatePairPoints(Vector3 middle, Vector3 direction, bool addTriangles = true)
        {
            var cross = Vector3.Cross(direction, Vector3.up) * Width;
            var count = MeshPoints.Count;

            MeshPoints.Add(middle + cross);
            MeshPoints.Add(middle - cross);

            if (addTriangles)
            {
                MeshTriangles.Add(count + 1);
                MeshTriangles.Add(count);
                MeshTriangles.Add(count + 2);

                MeshTriangles.Add(count + 1);
                MeshTriangles.Add(count + 2);
                MeshTriangles.Add(count + 3);
            }
        }
    }
}
