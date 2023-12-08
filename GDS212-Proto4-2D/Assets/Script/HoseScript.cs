using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseScript : MonoBehaviour
{
    public GameObject HoseWater;
    private bool isActive = true; // Initial state is active
    private float toggleInterval = 5f;
    private float timer = 0f;

    private SpriteRenderer rend;
    public Animator spriteAnimation;
    private bool currentState;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        spriteAnimation = GetComponent<Animator>();
        currentState = spriteAnimation.GetBool("IsOn");
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to toggle the object's state
        if (timer >= toggleInterval)
        {
            ToggleActiveState();
            timer = 0f; // Reset the timer
        }
    }

    private void ToggleActiveState()
    {
        isActive = !isActive; // Toggle the active state
        HoseWater.SetActive(isActive); // Set the object's active state
        spriteAnimation.SetBool("IsOn", !currentState);
    }
}
