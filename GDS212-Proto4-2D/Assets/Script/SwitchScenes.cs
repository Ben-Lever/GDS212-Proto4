using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = FindAnyObjectByType<Flowchart>();
    }

    public void LoadScene()
    {
        //SceneManager.LoadScene("Greybox", LoadSceneMode.Single);
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void KillGame()
    {
        Application.Quit();
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
