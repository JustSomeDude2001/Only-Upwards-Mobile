using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speedHorizontal = 5f;
    [SerializeField] private float speedVertical = 5f;
    [SerializeField] private float smoothing = 0.5f;

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction to move towards the target
            Vector3 direction = target.position - transform.position;

            // Calculate the movement amount for this frame based on horizontal and vertical speed
            float horizontalMovement = direction.x * speedHorizontal * Time.deltaTime;
            float verticalMovement = direction.y * speedVertical * Time.deltaTime;

            // Create a new position that is the current position interpolated towards the target position
            Vector3 newPosition = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);

            // Move the object to the new position
            transform.position = newPosition;
        }
    }
}
