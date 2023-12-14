using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed, turnSpeed = 0.1f;

    private int legsActive, legsTilt;

    public bool canMove = true;
    public List<GameObject> ignoreCollisions;

    public AudioSource bonk;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("bonk " + collision);
        foreach (GameObject collide in ignoreCollisions)
        {
            if (collision.gameObject == collide)
            {
                return;
            }
        }
        StartCoroutine(Bonk());
    }

    IEnumerator Bonk()
    {
        canMove = false;
        //bonk noise
        bonk.Play();
        for (int i = 0; i < 80; i++)
        {
            yield return new WaitForFixedUpdate();
            rb.MovePosition(transform.position + (-transform.up) / 20);
        }
        yield return new WaitForSeconds(0.1f);

        canMove = true;

        yield return null;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        legsActive = 0;
        legsTilt = 0;
        

        if (Input.GetKey(KeyCode.W))
        {
            legsActive++;
            legsTilt--;
        }
        if (Input.GetKey(KeyCode.A))
        {
            legsActive++;
            legsTilt++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            legsActive++;
            legsTilt--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            legsActive++;
            legsTilt++;
        }
        if (Input.GetKey(KeyCode.F))
        {
            legsActive++;
            legsTilt--;
        }
        if (Input.GetKey(KeyCode.G))
        {
            legsActive++;
            legsTilt++;
        }

        //negative just cos I don't wanna rewrite above stuff
        if (canMove){
            rb.MoveRotation(rb.rotation + turnSpeed * legsTilt / 10);

            rb.MovePosition(transform.position + (transform.up * moveSpeed * legsActive / 20));
        }
    }

    public void MoveOnOff()
    {
        canMove = !canMove;
    }
}
