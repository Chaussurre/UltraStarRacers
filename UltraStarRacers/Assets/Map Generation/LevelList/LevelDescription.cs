using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.generation
{
    [CreateAssetMenu]
    public class LevelDescription : ScriptableObject
    {
        [Serializable]
        public struct Zone
        {
            public MapZone zone;
            public float weight;
        }
        
        public List<Zone> Zones = new();

        public string Name;
        [TextArea] public string Description;
        public float Distance;
        public Color WallColor;
    }
}
