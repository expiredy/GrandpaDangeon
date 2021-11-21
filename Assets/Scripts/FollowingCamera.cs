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
        this.transform.position = new Vector3(targetForFollowing.position.x, targetForFollowing.position.y,
                                              this.transform.position.z);;
    }

}