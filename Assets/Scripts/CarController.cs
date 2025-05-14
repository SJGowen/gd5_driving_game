using UnityEngine;

public class CarController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 speed;
    public Transform Wheel_fl;
    public Transform Wheel_fr;
    public Vector3 sideViewOffset;
    public Vector3 driverViewOffset = new (0f, 4f, 1.4f);
    public float smoothSpeed = 5f;
    public float MoveSpeed = 10f;
    public float maxSteerAngle = 30f;
    public float steerSpeed = 5f;

    void Start()
    {
        mainCamera = Camera.main;
        sideViewOffset = mainCamera.transform.position - transform.position;
    }

    void Update()
    {        
        speed = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime * Vector3.forward;
        transform.Translate(speed);
        if (speed != Vector3.zero)
        {
            var rotation = Input.GetAxis("Horizontal") * 70 * Time.deltaTime * Vector3.up;
            transform.Rotate(rotation);
            if (rotation == Vector3.zero)
            {                 
                Wheel_fl.localRotation = Quaternion.identity;
                Wheel_fr.localRotation = Quaternion.identity;
            }
            else
            {
                float steerInput = Input.GetAxis("Horizontal") * maxSteerAngle;

                Quaternion targetRotation = Quaternion.Euler(0, steerInput, 0);

                Wheel_fl.localRotation = Quaternion.Lerp(Wheel_fl.localRotation, targetRotation, Time.deltaTime * steerSpeed);
                Wheel_fr.localRotation = Quaternion.Lerp(Wheel_fr.localRotation, targetRotation, Time.deltaTime * steerSpeed);
            }
        }
    }

    void LateUpdate()
    {
        // The following code has been commented out because it was causing the camera to switch views too frequently.
        //SwitchCameras(speed != Vector3.zero);
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
