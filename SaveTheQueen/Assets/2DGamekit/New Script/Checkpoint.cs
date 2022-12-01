using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public UnityEvent InArea;
    private Transform currentCheckpoint;

    private void Respawn ()
    {
        transform.position = currentCheckpoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.tag == "Checkpoint" )
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<AudioSource>().enabled = false;
            InArea.Invoke();
        }
    }
}
