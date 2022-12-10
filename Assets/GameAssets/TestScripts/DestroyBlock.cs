using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    public float lifeOfBullet;
    public int damage;
    
    void Start()
    {
        Destroy(gameObject, lifeOfBullet);
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.CompareTag(collision.gameObject.tag))
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject); 
            collision.gameObject.GetComponentInParent<Health>().Remove((int)damage);
            //GameObject.Find("Blocks").transform.position += Vector3.down;
            
        }
    }
}