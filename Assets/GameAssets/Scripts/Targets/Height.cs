using System;
using UniRx;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class Height : HealthDependentBehaviour
    {
        [SerializeField] private Transform target;

        [SerializeField] private float scalePerHealth = 1;

        [SerializeField] private GameSettings _gameSettings;
        
        public float Current => health.Current * scalePerHealth;

        private void Start()
        {
            scalePerHealth = _gameSettings.cylinderHeightScaleChange;
            health.Observe.Subscribe(current =>
            {
                var scale = target.localScale;
                scale.y = current * scalePerHealth;
                target.localScale = scale;
            }).AddTo(target);
        }
    }
}