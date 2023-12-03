using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyItemTracker : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int keyItems;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ItemCollected()
    {
        keyItems += 1;
        text.text = "Snacks:\n" + keyItems.ToString("0") + "/3";
    }
}
