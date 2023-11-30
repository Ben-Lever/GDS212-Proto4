using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntsScript : MonoBehaviour
{
    public float toggleInterval = 3f; // Time interval for toggling child objects
    private Transform[] childObjects; // Array to store child objects
    private int currentIndex = 0; // Index of the currently toggled child object
    private float timer = 0f; // Timer to track the interval

    private void Start()
    {
        // Get all the child objects of the parent
        int childCount = transform.childCount;
        childObjects = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i);
        }

        // Initially, turn off all child objects except the first one
        ToggleAllChildObjects(true);
        childObjects[currentIndex].gameObject.SetActive(false);
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to toggle to the next child object
        if (timer >= toggleInterval)
        {
            // Turn off the currently active child object
            childObjects[currentIndex].gameObject.SetActive(true);

            // Move to the next child object (wrap around if needed)
            currentIndex = (currentIndex + 1) % childObjects.Length;

            // Turn on the next child object
            childObjects[currentIndex].gameObject.SetActive(false);

            // Reset the timer
            timer = 0f;
        }
    }

    private void ToggleAllChildObjects(bool active)
    {
        foreach (Transform child in childObjects)
        {
            child.gameObject.SetActive(active);
        }
    }
}
