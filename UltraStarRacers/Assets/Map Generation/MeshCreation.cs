using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Map.generation
{
    public class MeshCreation : MonoBehaviour
    {
        public MeshFilter GroundMeshFilter;
        public MeshCollider GroundCollider;
        private Mesh meshGround;

        private List<Vector3> GroundPoints = new List<Vector3>();
        private List<int> GroundTriangles = new List<int>();

        public MeshFilter WallLeftMeshFilter;
        public MeshCollider WallLeftCollider;
        private Mesh meshWallLeft;

        private List<Vector3> WallLeftPoints = new List<Vector3>();
        private List<int> WallLeftTriangles = new List<int>();
        
        public MeshFilter WallRightMeshFilter;
        public MeshCollider WallRightCollider;
        private Mesh meshWallRight;

        private List<Vector3> WallRightPoints = new List<Vector3>();
        private List<int> WallRightTriangles = new List<int>();

        
        private void Awake()
        {
            meshGround = new Mesh();
            meshWallLeft = new Mesh();
            meshWallRight = new Mesh();
            
            GroundMeshFilter.mesh = meshGround;
            WallLeftMeshFilter.mesh = meshWallLeft;
            WallRightMeshFilter.mesh = meshWallRight;
        }

        public void CreateMesh(List<Vector3> points, MapZone zone, int StartIndex)
        {
            int endIndex = Mathf.Min(zone.PointCount + StartIndex, points.Count - 1);
            
            if (StartIndex == 0)
            {
                CreatePairPoints(points[0], Vector3.forward, zone);
                CreateTriangles();
                StartIndex++;
            }

            for (int i = StartIndex; i < endIndex - 1; i++)
            {
                CreatePairPoints(points[i], (points[i + 1] - points[i - 1]).normalized, zone);
                CreateTriangles();
            }

        }

        public void FinishMesh(List<Vector3> points, MapZone zone)
        { 
            CreatePairPoints(points[^1], points[^1] - points[^2], zone);
            meshGround.vertices = GroundPoints.ToArray();
            meshGround.triangles = GroundTriangles.ToArray();
            GroundCollider.sharedMesh = meshGround;

            meshWallLeft.vertices = WallLeftPoints.ToArray();
            meshWallLeft.triangles = WallLeftTriangles.ToArray();
            WallLeftCollider.sharedMesh = meshWallLeft;

            meshWallRight.vertices = WallRightPoints.ToArray();
            meshWallRight.triangles = WallRightTriangles.ToArray();
            WallRightCollider.sharedMesh = meshWallRight;
        }

        void CreatePairPoints(Vector3 middle, Vector3 direction, MapZone zone)
        {
            var cross = Vector3.Cross(direction, Vector3.up) * zone.PathWidth;

            GroundPoints.Add(middle + cross);
            GroundPoints.Add(middle - cross);
            
            WallLeftPoints.Add(middle + cross);
            WallLeftPoints.Add(middle + cross + Vector3.up * zone.WallHeight);
            
            WallRightPoints.Add(middle - cross);
            WallRightPoints.Add(middle - cross + Vector3.up * zone.WallHeight);
        }

        void CreateTriangles()
        {
            var count = GroundPoints.Count - 2;
            
            //GROUND
            GroundTriangles.Add(count + 1);
            GroundTriangles.Add(count);
            GroundTriangles.Add(count + 2);

            GroundTriangles.Add(count + 1);
            GroundTriangles.Add(count + 2);
            GroundTriangles.Add(count + 3);
            
            //WALL LEFT
            WallLeftTriangles.Add(count);
            WallLeftTriangles.Add(count + 1);
            WallLeftTriangles.Add(count + 2);

            WallLeftTriangles.Add(count + 2);
            WallLeftTriangles.Add(count + 1);
            WallLeftTriangles.Add(count + 3);
            
            //WALL RIGHT
            WallRightTriangles.Add(count + 1);
            WallRightTriangles.Add(count);
            WallRightTriangles.Add(count + 2);

            WallRightTriangles.Add(count + 1);
            WallRightTriangles.Add(count + 2);
            WallRightTriangles.Add(count + 3);
        }
    }
}
