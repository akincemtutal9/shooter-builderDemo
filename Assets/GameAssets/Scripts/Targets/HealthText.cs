using System;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace GameAssets.Scripts
{
    public class HealthText : HealthDependentBehaviour
    {
        [SerializeField] private TextMeshPro text;
        [SerializeField] private float offset = .1f;

        private void Start()
        {
            var scale = GetComponent<Height>();

            health.Observe
                .Subscribe(current =>
                {
                    text.transform.localPosition = Vector3.up * scale.Current * 2 + Vector3.up * offset;
                    text.text = current.ToString();
                })
                .AddTo(gameObject);
        }
    }
}