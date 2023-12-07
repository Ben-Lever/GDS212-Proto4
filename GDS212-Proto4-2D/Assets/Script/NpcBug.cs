using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcBug : MonoBehaviour
{
    public Flowchart flowchart;
    public string thisObject;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = FindAnyObjectByType<Flowchart>();
        thisObject = gameObject.name;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider Player)
    {
        Debug.Log("Entered Trigger");
        switch (gameObject.name)
        {
            case "TutBug1":
                flowchart.ExecuteBlock("TutBug1");
                break;
            case "TutBug2":

                break;
            case "TutBug3":

                break;
            default:
                break;
        }

        
        
    }
}
