using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameAssets.Scripts
{
    [Serializable]
    public class RandomXZScale
    {
        [SerializeField] private float min = 1;
        [SerializeField] private float max;

        
        public float Randomize()
        {
            return Random.Range(min, max);
        }
    }
}