using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreenUpdated : MonoBehaviour
{
    //All part of the UI win screen
    public GameObject TimeObject;
    public GameObject Objectives;
    public GameObject Snacks;
    public GameObject Buttons;

    //The main UI elements that will be turned off
    public GameObject Timer;
    public GameObject ObjectiveTracker;
    public GameObject SnacksTracker;

    //
    public TextMeshProUGUI FinalTimeText;
    public TextMeshProUGUI FinalObjectiveText;
    public TextMeshProUGUI FinalSnackText;

    //Will cause the UI to slide onscreen
    public RectTransform uiContainer; // Reference to the RectTransform of the UI container
    public float onScreenPositionX = 0; // X-coordinate when onscreen
    public float offScreenPositionX = -500; // X-coordinate when offscreen
    public float moveDuration = 0.25f; // Duration of the movement in seconds
    private Vector2 startPosition;
    private Vector2 onScreenPosition;
    private Vector2 offScreenPosition;

    void Start()
    {
        startPosition = uiContainer.anchoredPosition;
        onScreenPosition = new Vector2(onScreenPositionX, uiContainer.anchoredPosition.y);
        offScreenPosition = new Vector2(offScreenPositionX, uiContainer.anchoredPosition.y);

        FinalTimeText.text = Timer.GetComponentInChildren<Timer>().text.text;
        FinalObjectiveText.text = ObjectiveTracker.GetComponentInChildren<KeyItemTracker>().text.text;
        FinalSnackText.text = SnacksTracker.GetComponentInChildren<PillBugTracker>().text.text;
    }

    public void TurnOffUI()
    {
        //Turns off the main ui
        Timer.SetActive(false);
        ObjectiveTracker.SetActive(false);
        SnacksTracker.SetActive(false);

        //Turns off the win screen ui for dramatic effect
        TimeObject.SetActive(false);
        Objectives.SetActive(false);
        Snacks.SetActive(false);
        Buttons.SetActive(false);
    }
    private IEnumerator MoveUI()
    {
        float elapsedTime = 0;
        TurnOffUI();
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

        yield return new WaitForSeconds(1.0f);

        TimeObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        Objectives.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        Snacks.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        Buttons.SetActive(true);

        /*
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
        */
    }
}
