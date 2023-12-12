using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntWalking : MonoBehaviour
{
    public Transform objectToMove;
    public GameObject antLocation1;
    public Vector2 targetPosition;
    private float moveDuration = 7f; // Duration of the movement in seconds

    public Vector2 initialPosition;
    private float startTime;

    private void Start()
    {
        objectToMove = transform;

        //targetPosition = GameObject.Find("AntLocation1").transform.position;
        //antLocation1 = GameObject.Find("AntLocation1");
        //initialPosition = antLocation1.GetComponent<AntsSpawing>().thisSpawnPosition;
        startTime = Time.time;

        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            objectToMove.position = Vector2.Lerp(initialPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure that the object reaches the exact target position at the end.
        objectToMove.position = targetPosition;
        Destroy(gameObject);
    }
}
