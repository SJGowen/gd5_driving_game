using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public float elavationSpeed = 5f;
    private float currentElavation = 0f;
    void Update()
    {
        float elavationInput = Input.GetAxis("VerticalBarrel") * elavationSpeed * Time.deltaTime;
        currentElavation = Mathf.Clamp(currentElavation + elavationInput, -15f, 5f);
        transform.rotation = Quaternion.Euler(currentElavation, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
