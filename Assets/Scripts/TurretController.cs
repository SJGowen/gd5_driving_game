using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float rotationSpeed = 40f;

    void Update()
    {
        float rotationInput = Input.GetAxis("TurretRotation");
        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }
}
