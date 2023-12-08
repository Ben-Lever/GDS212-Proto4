using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AntsSpawing : MonoBehaviour
{
    public GameObject antPrefab;
    private float spawnInterval = 1f;
    public Vector2 spawnPosition; // Default position
    public float spawnRotationAngle = 0.0f; // Default rotation angle in degrees
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPrefabCoroutine());
        //spawnPosition = antPrefab.GetComponent<AntWalking>().initialPosition;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Destroy(other.gameObject);
    }
    private IEnumerator SpawnPrefabCoroutine()
    {
        while (true) // This will continue indefinitely; you may want to add a condition to stop it.
        {
            // Calculate the rotation based on the angle.
            Quaternion spawnRotation = Quaternion.Euler(0, 0, spawnRotationAngle);

            // Instantiate the prefab at the specified position and rotation.
            Instantiate(antPrefab, spawnPosition, spawnRotation);

            // Wait for the specified interval before spawning again.
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
