using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PropellerX : MonoBehaviour
{
    public float rotationSpeed = 1000f; // Speed of propeller rotation

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
