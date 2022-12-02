using System.Collections;
using System.Collections.Generic;
using GameAssets.Scripts;
using UniRx;
using UnityEngine;

public class TargetDie : HealthDependentBehaviour
{
    public Transform target;
    public float Current => health.Current;  
    void Start()
    {
        Observable.ReturnUnit().DelayFrame(1).Subscribe(_ =>
        {
        
        health.Observe.Subscribe(current =>
            {
                var _health = target.GetComponent<Health>().Current;
                _health = current;
                target.GetComponent<Health>().Current = _health;
                if (_health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        ).AddTo(gameObject);
        });
        
    }

  
}
