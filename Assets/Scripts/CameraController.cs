using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
        transform.rotation = player.rotation;
    }
}
