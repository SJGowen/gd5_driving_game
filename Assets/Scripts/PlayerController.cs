using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPosition;
    public float speed = 6;
    public float turnSpeed = 5f;
    public float maxTurnAngle = 30f;

    Rigidbody rb;
    float horizontalInput, verticalInput;

    public int playerIndex; // if this value is 1, it would be player 1, if this value was 2, it will be player 2


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Method 1, using translation for movement
        //transform.Translate(0,0,speed * Time.deltaTime);

        //Method 3, using the physics engine to move our object forward in world space
        //rb.AddForce(Vector3.forward * speed);

        //Method 4, using the physics engine to move our object forward in local space
        //rb.AddRelativeForce(Vector3.forward * speed);

        //Movement Mechanics

        //Recording Player Inputs
        verticalInput = Input.GetAxis("Vertical" + playerIndex); // Up, Down, W, S, Analogue Stick Up/Down


        //Method 2, using translation for movement but while using short forms
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        if (verticalInput != 0)
        {
            //Recording Player Inputs
            horizontalInput = Input.GetAxis("Horizontal" + playerIndex); // Left, Right, A, D, Analogue Stick Left/Right

            //Move the player left and right
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * maxTurnAngle * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reset the car's position and rotation
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
        }
    }
}