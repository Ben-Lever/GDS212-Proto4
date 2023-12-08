using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NpcBug : MonoBehaviour
{
    public Flowchart flowchart;
    public string thisObject;
    public GameObject CentipedeHead;
    public Collider2D thisCollider;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = FindAnyObjectByType<Flowchart>();
        thisObject = gameObject.name;
        CentipedeHead = GameObject.Find("Head");
        thisCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Player)
    {
        Debug.Log("Entered Trigger");
        switch (gameObject.name)
        {
            case "TutBug1":
                flowchart.ExecuteBlock("TutBug1");
                thisCollider.enabled = false;
                break;
            case "TutBug2":
                flowchart.ExecuteBlock("TutBug2");
                thisCollider.enabled = false;
                break;
            case "TutBug3":
                flowchart.ExecuteBlock("TutBug3");
                thisCollider.enabled = false;
                break;
            case "TutBug4":
                flowchart.ExecuteBlock("TutBug4");
                thisCollider.enabled = false;
                break;
            default:
                break;
        }

        
        
    }
}
