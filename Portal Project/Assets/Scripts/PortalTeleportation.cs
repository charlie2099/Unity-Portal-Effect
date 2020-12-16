using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportation : MonoBehaviour
{
    public GameObject otherPortal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2.0f;
            other.transform.rotation = otherPortal.transform.rotation;
        }
    }
}
