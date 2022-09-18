using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ship.Controls
{
    public class FlameMeshCreator : MonoBehaviour
    {
        
        
        [HideInInspector]
        public Mesh mesh;

        public MeshFilter meshFilter;
        
        private void Start()
        {
            mesh = new Mesh();

            mesh.vertices = new[]
            {
                Vector3.zero, Vector3.left, Vector3.up
            };
            mesh.triangles = new[]
            {
                0, 1, 2
            };
            
            meshFilter.mesh = mesh;
        }
    }
}
