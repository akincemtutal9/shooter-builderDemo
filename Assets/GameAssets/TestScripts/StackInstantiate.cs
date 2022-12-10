using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class StackInstantiate : MonoBehaviour
{

    public static StackInstantiate instance;
    
    private float distanceBetweenObjects;
    [SerializeField] private GameObject instantiateObj;
    [SerializeField] private Transform prevObject;
    [SerializeField] private int count;
    [SerializeField] private int setFirstCylinderStartAngle;
    [SerializeField] private float worldSpawnAngle;
    [SerializeField] private float distance;
    [SerializeField] private float distanceMultiplier;


    private const string Blocks = nameof(Blocks);
    private const string Root = nameof(Root);
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        distanceBetweenObjects = prevObject.localScale.y;
        InstantiateObj();
    }

    public void InstantiateObj()
    {
        var root = new GameObject(Root);
        float distance = 0;
        for (int i = 0; i < count; i++)
        {
            var position = prevObject.position;
            position.x = Mathf.Cos((float) (setFirstCylinderStartAngle + i) / count * worldSpawnAngle * Mathf.Deg2Rad) * distance *
                         (distanceMultiplier * (1 + (float) i / count));
            position.z = Mathf.Sin((float)(setFirstCylinderStartAngle + i) / count * worldSpawnAngle * Mathf.Deg2Rad) * distance *
                         (distanceMultiplier * (1 + (float) i / count));
            var newTarget = Instantiate(instantiateObj, position , Quaternion.identity);
            newTarget.transform.SetParent(root.transform);
            
            
        }
        
       /* var blocks = new GameObject(Blocks);
        for (int i = 0; i < Random.Range(3,10); i++)
        {
            Vector3 desPos = prevObject.localPosition;
            desPos.y += distanceBetweenObjects + i;
            //var prefab  = Instantiate(instantiateObj, desPos, Quaternion.identity);
            prefab.transform.SetParent(root.transform);
        }
        */
        
    }
}