using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    
    [SerializeField] public Transform targetForFollowing;
    [SerializeField] public Vector3 offset;

    private const float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = targetForFollowing.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        this.transform.position = smoothedPosition;
        this.transform.LookAt(targetForFollowing);
    }

}