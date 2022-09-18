using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.generation
{
    public class MapTraceGeneration : MonoBehaviour
    {
        public List<Vector3> points;

        public List<Vector3> GetPoints()
        {
            return points;
        }
    }
}
