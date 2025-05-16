using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    //public float rotationSpeed;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * verticalInput * 50 * Time.deltaTime);

        // roll the plane left/right based on left/right arrow keys
        var roll = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back * roll * 50 * Time.deltaTime);
    }
}
