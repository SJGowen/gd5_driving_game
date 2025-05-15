using UnityEngine;

public class CarController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 speed;
    private Vector3 startPosition;
    public Transform wheel_fl;
    public Transform wheel_fr;
    public Vector3 sideViewOffset = new(0, 0, 0);
    public Vector3 driverViewOffset = new (0f, 1.4f, 1);
    public float smoothSpeed = 5f;
    public float moveSpeed = 10f;
    public float maxSteerAngle = 30f;
    public float steerSpeed = 5f;
    public bool switchCameras = false;

    void Start()
    {
        mainCamera = Camera.main;
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
            if (rotation == Vector3.zero)
            {                 
                wheel_fl.localRotation = Quaternion.identity;
                wheel_fr.localRotation = Quaternion.identity;
            }
            else
            {
                float steerInput = Input.GetAxis("Horizontal") * maxSteerAngle;

                Quaternion targetRotation = Quaternion.Euler(Vector3.up * steerInput);

                wheel_fl.localRotation = Quaternion.Lerp(wheel_fl.localRotation, targetRotation, Time.deltaTime * steerSpeed);
                wheel_fr.localRotation = Quaternion.Lerp(wheel_fr.localRotation, targetRotation, Time.deltaTime * steerSpeed);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the car's position and rotation
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
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
