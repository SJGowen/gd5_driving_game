using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed of turret rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("TurretRotation");
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }
}
