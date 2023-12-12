using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class KidBugs : MonoBehaviour
{
    public float moveDistance = 1.0f;   // The distance to move forward and back.
    public float moveSpeed = 1.0f;      // The speed at which the object moves.
    public float pauseTime = 1.0f;      // The time to pause between forward and backward movements.

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        // Store the initial and target positions.
        initialPosition = transform.position;
        targetPosition = transform.position + transform.up * moveDistance;

        // Start the movement coroutine.
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            // Move the object forward.
            float distanceCovered = 0.0f;
            while (distanceCovered < moveDistance)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.Translate(transform.up * step);
                distanceCovered += step;
                yield return null;
            }

            // Pause for a moment.
            yield return new WaitForSeconds(pauseTime);

            // Move the object back to its initial position.
            float distanceBack = 0.0f;
            while (distanceBack < moveDistance)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.Translate(-transform.up * step);
                distanceBack += step;
                yield return null;
            }

            // Pause for a moment again.
            yield return new WaitForSeconds(pauseTime);
        }
    }
}
