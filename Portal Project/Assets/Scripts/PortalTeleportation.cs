using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportation : MonoBehaviour
{
    public GameObject otherPortal;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = otherPortal.transform.position + other.transform.forward * 1;
        }
    }
}
