using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public Transform target;
    public float smoothing = 0.2f;       // The speed with which the camera will be following.
    Vector3 velocity = Vector3.zero;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothing);
        transform.position = smoothedPosition;
    }
}
