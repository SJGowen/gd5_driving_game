using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public Transform plane;
    public Vector3 offset;
    public bool followBehindPlane = false;

    // Start is called before the first frame update
    void Start()
    {
        // plane = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = plane.transform.position + offset;
    }
}
