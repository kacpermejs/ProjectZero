using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float thrustSpeed = 10f;  // Forward thrust speed
    [SerializeField] private float turnFactor = 0.2f;
    [SerializeField] private float grip = 0.2f;
    [Space]
    [SerializeField] private Rigidbody2D boatRigidbody;
    [SerializeField] private Transform rudderPivotPoint;
    
    private float horizontalInput;
    private float verticalInput;

    private Vector2 rudderForce;
    Vector2 rudderOffset;
    Vector2 centrifugalForce;

    private void FixedUpdate()
    {
        // Apply forces and rotation to the boat based on the input
        Vector2 forwardForce = transform.up * verticalInput * thrustSpeed;
        boatRigidbody.AddForce(forwardForce);

        Vector2 steeringDir = boatRigidbody.transform.right;
        float forwardVelocity = Vector2.Dot(boatRigidbody.velocity, boatRigidbody.transform.up);

        rudderForce = steeringDir * -horizontalInput * forwardVelocity * turnFactor;
        rudderOffset = rudderPivotPoint.position - transform.position;

        boatRigidbody.AddForceAtPosition(rudderForce, boatRigidbody.position + rudderOffset);

        //grip
        Vector2 worldVelocity = boatRigidbody.velocity;
        float sideVelocity = Vector2.Dot(steeringDir, worldVelocity);

        float desiredVelChange = -sideVelocity * grip;

        float acc = desiredVelChange / Time.fixedDeltaTime;

        centrifugalForce = steeringDir * boatRigidbody.mass * acc;

        boatRigidbody.AddForce(centrifugalForce);
        

    }

    public void OnAccelerateInput(InputAction.CallbackContext context)
    {
        verticalInput = context.ReadValue<float>();
    }

    public void OnTurnInput(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<float>(); //right positive left negative
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine((Vector2)transform.position + rudderOffset, (Vector2)transform.position + rudderForce + rudderOffset);
        Gizmos.DrawSphere((Vector2)transform.position + rudderForce + rudderOffset, 0.1f);

        Gizmos.color = Color.black;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + centrifugalForce );
        Gizmos.DrawSphere((Vector2)transform.position + centrifugalForce, 0.1f);

        // Draw the forward vector
        Gizmos.color = Color.magenta;
        Vector2 forwardVelocity = Vector2.Dot(boatRigidbody.velocity, transform.up) * transform.up;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + forwardVelocity);

        Gizmos.color = Color.green;

        // Draw right velocity component
        Vector2 rightVelocity = Vector2.Dot(boatRigidbody.velocity, transform.right) * transform.right;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + rightVelocity);
    }
}

