using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint; //We'll store our last checkpoint here
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn ()
    {
        transform.position = currentCheckpoint.position; //Move player to checkpoint position
        playerHealth.Respawn();//Restore player health and reset animation

        // Camera.main.GetComponent<CameraController>().MoveToNewRoom(transform.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
