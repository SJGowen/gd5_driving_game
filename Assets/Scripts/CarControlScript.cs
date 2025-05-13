using UnityEngine;

public class CarControlScript : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 speed;
    public Vector3 sideViewOffset;
    public Vector3 driverViewOffset = new (0f, 4f, 1.4f);
    public float smoothSpeed = 5f;
    public float MoveSpeed = 10f;

    void Start()
    {
        mainCamera = Camera.main;
        sideViewOffset = mainCamera.transform.position - transform.position;
    }

    void Update()
    {        
        speed = Vector3.forward * Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        transform.Translate(speed);
        if (speed != Vector3.zero)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * 70 * Time.deltaTime, 0);
        }
    }

    void LateUpdate()
    {
        SwitchCameras(speed != Vector3.zero);
    }

    void SwitchCameras(bool isMoving)
    {
        Vector3 targetOffset = isMoving ? driverViewOffset : sideViewOffset;

        // Smoothly update camera position relative to the vehicle
        Vector3 targetPosition = transform.position + transform.TransformDirection(targetOffset);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Make camera face the same direction as the vehicle
        Quaternion targetRotation = isMoving
            ? transform.rotation  // Match vehicle's rotation when moving
            : Quaternion.LookRotation(transform.position - mainCamera.transform.position, Vector3.up); // Face vehicle when stationary

        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}
