using UnityEngine;
using UnityEngine.ProBuilder;

public class BulletController : MonoBehaviour
{
    public GameObject projectile;
    public GameObject explodingProjectile;
    public float launchVelocity = 1200f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(explodingProjectile, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
        }
    }
}
