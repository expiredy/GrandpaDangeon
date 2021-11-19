using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject gun;
    public float bulletForce = 500f;

    private Rigidbody2D playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition -= transform.position;

        // gun rotation follows mouse
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // shooting
        if (Input.GetMouseButtonUp(0))
        {
            mousePosition = mousePosition.normalized;
            playerRB.AddForce(-mousePosition * bulletForce);
        }
    }
}