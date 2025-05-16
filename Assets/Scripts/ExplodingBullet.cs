using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionRadius = 5f;
    public float explosionForce = 400f;

    void OnCollisionEnter(Collision collision)
    {
        // Instantiate explosion effect
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Apply explosion force to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // Destroy the bullet
        Destroy(gameObject);
        Destroy(explosionPrefab, 3f);
    }
}
