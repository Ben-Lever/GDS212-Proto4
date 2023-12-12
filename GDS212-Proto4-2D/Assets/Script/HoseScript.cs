using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseScript : MonoBehaviour
{
    public GameObject HoseWater;
    private bool isActive = false; // Initial state is active
    private float toggleInterval = 5f;
    private float timer = 0f;

    private SpriteRenderer rend;
    public Animator spriteAnimation;
    public bool currentState;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        spriteAnimation = GetComponent<Animator>();
        
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
        currentState = spriteAnimation.GetBool("IsOn");
    }

    private void ToggleActiveState()
    { 
        spriteAnimation.SetBool("IsOn", !currentState);
        StartCoroutine(PauseForOneSecond());

    }
    IEnumerator PauseForOneSecond()
    {
        if (currentState == false)
        {
            yield return new WaitForSeconds(1.25f);
        }
        else
        {
            yield return new WaitForSeconds(0.75f);
        }
        isActive = !isActive; // Toggle the active state
        HoseWater.SetActive(isActive); // Set the object's active state
    }
}
