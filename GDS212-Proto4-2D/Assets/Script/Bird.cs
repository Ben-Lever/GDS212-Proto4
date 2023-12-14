using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float birdArriveFrequency, timeToReact;
    private float timer;
    private Rigidbody2D rb;
    public Vector3 startSpot, driveBySlow, driveByFast;
    private AudioSource caw;
    public GameObject ambience, stun;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        caw = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 1;
        BirdComing();
    }


    //Every 10 seconds 1/3 chance for bird to attack
    public void BirdComing()
    {
        
        if (((int)timer) % (60*birdArriveFrequency) == 0)
        {
            if (Random.Range(1, 1) == 1) {
                Debug.Log("bird caw");
                caw.Play();
                StartCoroutine(IsPlayerMoving());
            }
        }
    }

    //checks if player is moving during attack
    private IEnumerator IsPlayerMoving()
    {
        yield return new WaitForSeconds(timeToReact);
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            DriveByFast();
        }
        else
        {
            DriveBySafe();
        }
        yield return null;
    }


    public void DriveBySafe()
    {
        Debug.Log("Slow bird");
        transform.position = startSpot;
        rb.velocity = driveBySlow;
    }

    public void DriveByFast()
    {
        transform.position = startSpot;
        rb.velocity = driveByFast;
        Debug.Log("Stun noise");
        stun.GetComponent<AudioSource>().Play();
        player.GetComponent<RigidbodyMovement>().canMove = false;
        StartCoroutine(UnStun());
    }

    public IEnumerator UnStun()
    {
        for (int i = 0; i <= 15; i++)
        {
            yield return new WaitForSeconds(0.1f);
            player.GetComponent<SpriteRenderer>().color = Color.clear;
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().color = Color.white;
        }

        player.GetComponent<RigidbodyMovement>().canMove = true;
        yield return null;
    }
}
