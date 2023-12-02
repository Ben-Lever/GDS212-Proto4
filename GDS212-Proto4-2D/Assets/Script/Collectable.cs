using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public List<GameObject> collectable, keyItem;

    public GameObject particles;
    public GameObject timer, pillbugCollector;

    private AudioSource audioSound;

    private void Start()
    {
        audioSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("grab");
        foreach (GameObject want in collectable)
        {
            if (want == collision.gameObject)
            {
                //Emit Particles on find
                GameObject particleEffect = Instantiate(particles, transform.position, Quaternion.identity);
                Destroy(particleEffect, 10f);

                //play sound
                audioSound.Play();

                //Grant time bonus
                timer.GetComponent<Timer>().time -= 15f;

                //update text
                pillbugCollector.GetComponent<PillBugTracker>().bugCollected();

                //Removes at end of frame to not throw errors
                StartCoroutine(RemoveStuff(want));
                return;
            }
        }
    }

    private IEnumerator RemoveStuff(GameObject removeThis)
    {
        yield return new WaitForEndOfFrame();
        collectable.Remove(removeThis);
        Destroy(removeThis);
        Debug.Log("worked");
        yield return null;
    }

    //list of gameobjects
    //list of bools
    //when bump with gameobject disable said object
    //grant time bonus or appropriate bool

}
