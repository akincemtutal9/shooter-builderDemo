using System;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class HealthDependentBehaviour : MonoBehaviour
    {
        protected Health health;

        protected virtual void Awake()
        {
            health = GetComponent<Health>();
        }
    }
}