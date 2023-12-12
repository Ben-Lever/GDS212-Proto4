using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SwitchScenes : MonoBehaviour
{
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = FindAnyObjectByType<Flowchart>();
    }

    public void ReloadScene()
    {
        flowchart.ExecuteBlock("ReloadScene");
    }
    public void BackToMenu()
    {
        flowchart.ExecuteBlock("BackToMenu");
    }

}
