using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropForce : MonoBehaviour
{
    public float minForceMagnitude = 5f;
    public float maxForceMagnitude = 15f;
    [Space]
    public float minAngularVelocity = -90f; // Minimum angular velocity in degrees per second.
    public float maxAngularVelocity = 90f;

    void Start()
    {
        Rigidbody2D treeTopRb = GetComponent<Rigidbody2D>();
        Vector2 randomForceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
        float randomForceMagnitude = Random.Range(minForceMagnitude, maxForceMagnitude);
        treeTopRb.AddForce(randomForceDirection * randomForceMagnitude, ForceMode2D.Impulse);

        // Apply random angular velocity to the tree top's Rigidbody2D component.
        float randomAngularVelocity = Random.Range(minAngularVelocity, maxAngularVelocity);
        treeTopRb.angularVelocity = randomAngularVelocity;
    }
}
