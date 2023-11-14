using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Important variables
    public float baseSpeed;
    public float speedBoostAmount;

    private float currentSpeed;
    private Vector3 currentPos;

    void Start()
    {
        // Setup variables
        currentSpeed = baseSpeed;
        currentPos = transform.position;
    }

    void FixedUpdate()
    {
        // Get input vector
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input = input.normalized;
        
        // Check if speed should be increased
        if (Input.GetKey(KeyCode.LeftShift)) {
             currentSpeed = baseSpeed + speedBoostAmount;
        } else if (Input.GetKey(KeyCode.Space)) {
             currentSpeed = baseSpeed - speedBoostAmount;
        } else {
            currentSpeed = baseSpeed;
        }
        
        // Debug
        print(input + " | Current Speed: " + currentSpeed);

        // Actually change position
        if (input.x <= -.5)
        {
            currentPos.x -= currentSpeed;
            transform.position = currentPos;
        }

        if (input.x >= .5)
        {
            currentPos.x += currentSpeed;
            transform.position = currentPos;
        }

        if (input.y <= -.5)
        {
            currentPos.y -= currentSpeed;
            transform.position = currentPos;
        }

        if (input.y >= .5)
        {
            currentPos.y += currentSpeed;
            transform.position = currentPos;
        }
    }
}
