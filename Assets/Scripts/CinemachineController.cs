using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    public bool isFirstPerson = false;
    public Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = Vector3.zero;
    }

    void Update()
    {
    }

    private void LateUpdate()
    {
        transform.position = transform.position + cameraOffset;

        if (Input.GetKeyDown(KeyCode.P))
        {
            isFirstPerson = !isFirstPerson;
            cameraOffset = isFirstPerson ? new Vector3(0f, 11.5f, -12) : Vector3.zero;
        }
    }
}
