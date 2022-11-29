using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class Health : MonoBehaviour
{
    private IntReactiveProperty current = new(0);

    public IObservable<int> Observe => current;

    public int Current => current.Value;

    public void Add(int amount) => current.Value += amount;

    public void Remove(int amount) => current.Value -= amount;
    
    public void Set(int value) => current.Value = value;
    
    // otomatik ateş
    // merkezde dursun silindirler buna gelsin
    // OR
    // İleri dogru gidiyo oyuncu saga sola haraket yok ölmeden bölümün sonuna varmaya çalışır.
    
    
    //Farklı mermiler.
    // lean pool
    
    }