using UnityEngine;

public class PushBullets : MonoBehaviour
{
    public float lifeOfBullet;
    public int damage;
    public int pushForce;
    private Vector3 direction;
    private GameObject player;
    
    
    [SerializeField] private GameSettings _gameSettings;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        direction = player.transform.position - transform.position;

        lifeOfBullet = _gameSettings.pushBulletLife;
        damage = _gameSettings.pushBulletDamage;
        pushForce = _gameSettings.pushBulletPushForce;
        Destroy(gameObject, lifeOfBullet);
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Health>().Remove(damage);
            collision.gameObject.transform.Translate(-direction.normalized * pushForce * Time.deltaTime);
            Destroy(gameObject);
            
        }
        // Destroy etsin asobservable a bak
        // 
    }
}