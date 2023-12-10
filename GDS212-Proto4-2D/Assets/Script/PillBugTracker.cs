using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PillBugTracker : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int pillbugsCollected;

    public RectTransform uiContainer; // Reference to the RectTransform of the UI container
    public float onScreenPositionX = 0; // X-coordinate when onscreen
    public float offScreenPositionX = -500; // X-coordinate when offscreen
    public float moveDuration = 0.25f; // Duration of the movement in seconds

    private Vector2 startPosition;
    private Vector2 onScreenPosition;
    private Vector2 offScreenPosition;

    public GameObject timerReduction;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();

        startPosition = uiContainer.anchoredPosition;
        onScreenPosition = new Vector2(onScreenPositionX, uiContainer.anchoredPosition.y);
        offScreenPosition = new Vector2(offScreenPositionX, uiContainer.anchoredPosition.y);

        timerReduction.SetActive(false);
    }

    public void snackCollected()
    {
        StartCoroutine(MoveUI());
        pillbugsCollected += 1;
        text.text = "x" + pillbugsCollected.ToString("0");
    }

    private IEnumerator MoveUI()
    {
        float elapsedTime = 0;
        timerReduction.SetActive(true);
        while (elapsedTime < moveDuration)
        {
            // Interpolate the position between start and on-screen position based on the elapsed time
            float t = elapsedTime / moveDuration;
            uiContainer.anchoredPosition = Vector2.Lerp(startPosition, onScreenPosition, t);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure that the UI reaches the exact on-screen position at the end
        uiContainer.anchoredPosition = onScreenPosition;

        // Wait for a few seconds before moving the UI back offscreen
        yield return new WaitForSeconds(2.0f);

        // Move the UI back offscreen
        elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            // Interpolate the position between on-screen and off-screen position based on the elapsed time
            float t = elapsedTime / moveDuration;
            uiContainer.anchoredPosition = Vector2.Lerp(onScreenPosition, offScreenPosition, t);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure that the UI reaches the exact off-screen position at the end
        uiContainer.anchoredPosition = offScreenPosition;
        timerReduction.SetActive(false);
    }
}
