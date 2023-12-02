using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PillBugTracker : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int pillbugsCollected;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void bugCollected()
    {
        pillbugsCollected += 1;
        text.text = "Pillbugs\n" + pillbugsCollected.ToString("0");
    }
}
