using UnityEngine;

public class TankController : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed = 10f;
    public float turnSpeed = 5f;
    public float maxTurnAngle = 30f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        var horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * maxTurnAngle * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
        }
    }
}
