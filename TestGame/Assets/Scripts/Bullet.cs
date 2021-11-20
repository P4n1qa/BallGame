using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float radius;


    private float _force;
    private float _speed = 5f;

    void Start()
    {
        rb.velocity = transform.right * _speed;
    }
    private void OnTriggerEnter(Collider collision) 
    {
        Explode();
    }
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_force, transform.position, radius);
            }
            EnemyDeath dest = nearbyObject.GetComponent<EnemyDeath>();
            if (dest != null)
            {
                dest.Destroy();
            }
        }
        Destroy(gameObject);
    }
}
