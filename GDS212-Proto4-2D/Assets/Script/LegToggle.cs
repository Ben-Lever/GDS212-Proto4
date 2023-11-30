using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegToggle : MonoBehaviour
{
    private SpriteRenderer rend;

    public Color stoppedColor = Color.red;
    public Color movingColor = Color.green;
    public KeyCode keyInput;
    public Animator spriteAnimation;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        spriteAnimation = GetComponent<Animator>();
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyInput))
        {
            rend.color = stoppedColor;

            spriteAnimation.SetBool("Moving", true);
        }
        else
        { 
            rend.color = movingColor;

            spriteAnimation.SetBool("Moving", false);
        }
    }
}
