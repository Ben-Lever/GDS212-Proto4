using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwapper : MonoBehaviour
{
    public SpriteRenderer rend;
    public List<Sprite> imageList;
    public int listInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tutorial()
    {
        rend.sprite = imageList[listInt];
        listInt++;
    }
}
