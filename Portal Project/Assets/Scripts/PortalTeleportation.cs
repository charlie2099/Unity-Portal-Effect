using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportation : MonoBehaviour
{
    public GameObject otherPortal;

    [SerializeField]
    private float spawnOffset = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * spawnOffset;
            other.transform.rotation = otherPortal.transform.rotation;
        }
    }
}
