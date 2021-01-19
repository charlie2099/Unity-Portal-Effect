using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform other_portal;
    private bool playerColliding = false;

    void Update()
    {
        if(playerColliding)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float playerMoved = Vector3.Dot(transform.up, portalToPlayer);

            // If true the player has moved across the portal
            if(playerMoved < 0f) // uses cos angle to determine a collision, and a crossover to the other portal
            {
                float rotation_difference = Quaternion.Angle(transform.rotation, other_portal.rotation);
                rotation_difference += 180;
                player.Rotate(Vector3.up, rotation_difference);

                Vector3 offset = Quaternion.Euler(0f, rotation_difference, 0f) * portalToPlayer;
                player.position = other_portal.position + offset;

                playerColliding = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerColliding = false;
        }
    }
}
