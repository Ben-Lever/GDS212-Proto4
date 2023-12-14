using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTheGame : MonoBehaviour
{
    public GameObject gameUI, winScreen, keyItems, timer, timerWin, pillBugCollected, pillBugWin, bird;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exited safe area");
        bird.SetActive(true);
        timer.GetComponent<Timer>().timerStarted = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bird.SetActive(false);
        //Debug.Log("hmm");
        if (keyItems.GetComponent<KeyItemTracker>().keyItems >= 3)
        {
            /*
            gameUI.SetActive(false);

            pillBugWin.GetComponent<TextMeshProUGUI>().text = "You brought home snacks for all your friends and found " + pillBugCollected.GetComponent<PillBugTracker>().pillbugsCollected.ToString() + " new pill bug friends.";
            timerWin.GetComponent<TextMeshProUGUI>().text = timer.GetComponent<Timer>().timeInSeconds.ToString("0.0");
            winScreen.SetActive(true);
            */

            winScreen.GetComponent<WinScreenUpdated>().TurnOnWinScreen();

        }
    }

   
}
