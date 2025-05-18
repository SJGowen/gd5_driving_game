using UnityEngine;

public class VanController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 speed;
    private Vector3 startPosition;
    public Transform wheel_fl;
    public Transform wheel_fr;
    public Vector3 sideViewOffset = new(0, 0, 0);
    public Vector3 driverViewOffset = new (0, 1.4f, 1);
    public float smoothSpeed = 5f;
    public float moveSpeed = 10f;
    public float maxSteerAngle = 30f;
    public float steerSpeed = 5f;
    public bool switchCameras = false;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.transform.position = new Vector3(14, 4, 5);
        mainCamera.transform.rotation = Quaternion.Euler(0, -90, 0);
        startPosition = transform.position;
        sideViewOffset = mainCamera.transform.position - transform.position;
    }

    void Update()
    {        
        speed = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * Vector3.forward;
        transform.Translate(speed);
        if (speed != Vector3.zero)
        {
            var rotation = Input.GetAxis("Horizontal") * 70 * Time.deltaTime * Vector3.up;
            transform.Rotate(rotation);

            SteerVehicle(rotation);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the car's position and rotation
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
        }
    }

    private void SteerVehicle(Vector3 rotation)
    {
        if (rotation == Vector3.zero)
        {
            // Straighten the wheels when not turning
            wheel_fl.localRotation = Quaternion.identity;
            wheel_fr.localRotation = Quaternion.identity;
        }
        else
        {
            // Calculate the target rotation based on the steering input
            float steerInput = Input.GetAxis("Horizontal") * maxSteerAngle;

            Quaternion targetRotation = Quaternion.Euler(Vector3.up * steerInput);

            wheel_fl.localRotation = Quaternion.Lerp(wheel_fl.localRotation, targetRotation, Time.deltaTime * steerSpeed);
            wheel_fr.localRotation = Quaternion.Lerp(wheel_fr.localRotation, targetRotation, Time.deltaTime * steerSpeed);
        }
    }

    void LateUpdate()
    {
        if (switchCameras) SwitchCameras(speed != Vector3.zero);
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
