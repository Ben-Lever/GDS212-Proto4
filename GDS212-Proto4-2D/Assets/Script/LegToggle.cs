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
    public enum SideOfBodyEnum { None,Left,Right };
    public SideOfBodyEnum sideOfBody;
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
            switch (sideOfBody)
            {
                case SideOfBodyEnum.Left:
                    spriteAnimation.SetBool("Left", true);
                    break;
                case SideOfBodyEnum.Right:
                    spriteAnimation.SetBool("Right", true);
                    break;
                default:
                    Debug.Log("SideOfBody not assigned");
                    break;
            }
  
        }
        else
        { 
            rend.color = movingColor;

            spriteAnimation.SetBool("Moving", false);
            spriteAnimation.SetBool("Left", false);
            spriteAnimation.SetBool("Right", false);
        }
    }
}
