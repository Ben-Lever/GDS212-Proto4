using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AntsSpawing : MonoBehaviour
{
    public GameObject antPrefab;

    public string thisObject;

    private float spawnInterval = 1f;
    public Vector2 spawnPosition1; // Default position
    public Vector2 spawnPosition2;
    public Vector2 thisSpawnPosition;
    public float spawnRotationAngle = 0.0f; // Default rotation angle in degrees
    // Start is called before the first frame update
    void Start()
    {
        thisObject = gameObject.name;
        if (thisObject == "AntLocation1")
        {
            thisSpawnPosition = spawnPosition1;
        }
        else if (thisObject == "AntLocation2")
        {
            thisSpawnPosition = spawnPosition2;
        }
        StartCoroutine(SpawnPrefabCoroutine());
        //spawnPosition = antPrefab.GetComponent<AntWalking>().initialPosition;
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Destroy(other.gameObject);
    }
    */

    private IEnumerator SpawnPrefabCoroutine()
    {
        int antCount = 0;

        while (true) // This will continue indefinitely; you may want to add a condition to stop it.
        {
            // Calculate the rotation based on the angle.
            Quaternion spawnRotation = Quaternion.Euler(0, 0, spawnRotationAngle);

            // Check if it's time to instantiate an ant.
            if (antCount % 5 != 0)
            {
                // Instantiate the prefab at the specified position and rotation.
                GameObject newObject = Instantiate(antPrefab, thisSpawnPosition, spawnRotation);

                // Access the AntWalking component and set its variables.
                AntWalking antWalkingComponent = newObject.GetComponent<AntWalking>();
                if (antWalkingComponent != null)
                {
                    antWalkingComponent.initialPosition = thisSpawnPosition;
                    antWalkingComponent.targetPosition = gameObject.transform.position;
                }
            }

            antCount++;

            // Wait for the specified interval before spawning again.
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
