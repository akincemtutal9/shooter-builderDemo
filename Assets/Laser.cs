using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defaultDistance = 100;
    public LineRenderer m_lineRenderer;
    public Transform laserSpawnPoint;
    public Transform m_transform; 
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_transform.position, transform.TransformDirection(Vector3.forward), out hit,defaultDistance))
        {
            Debug.DrawRay(laserSpawnPoint.position, laserSpawnPoint.transform.TransformDirection(Vector3.forward) * defaultDistance);
            Debug.DrawLine(laserSpawnPoint.position, hit.point);
        }
        
    }

    void DrawRay(Vector3 startPosition, Vector3 endPosition)
    {
        m_lineRenderer.SetPosition(0,startPosition);
        m_lineRenderer.SetPosition(1,endPosition);
    }
}
