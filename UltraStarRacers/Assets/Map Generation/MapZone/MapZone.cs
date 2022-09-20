using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.generation
{
    //[CreateAssetMenu("Map Zone", "Map Generation")]
    [CreateAssetMenu]
    public class MapZone : ScriptableObject
    {
        public int PointCount;
        public float distanceBetweenPoints;
        public float AngleBetweenPoints;
        public int AngleLockMin;
        public int AngleLockMax;
        public float PathWidth;
        public float WallHeight;
        
        [ContextMenu("Check validity")]
        private void CheckValidInfos()
        {
            float maxAngle = 90 - Mathf.Acos(distanceBetweenPoints / (2 * PathWidth)) * Mathf.Rad2Deg;
            Debug.Log($"Max Angle : {maxAngle}");
            if (maxAngle < AngleBetweenPoints)
            {
                Debug.LogError("Map generation infos can intersect");
            }
        }
    }
}
