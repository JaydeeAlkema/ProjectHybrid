using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing;
    [SerializeField] private Vector3 offset;



    void FixedUpdate()
    {
        Vector3 desiredLocation = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredLocation, smoothing);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
