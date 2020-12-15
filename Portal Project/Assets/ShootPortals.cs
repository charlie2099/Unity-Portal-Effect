﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPortals : MonoBehaviour
{
    public GameObject Portal_1;
    public GameObject Portal_2;

    GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            portalShoot(Portal_1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            portalShoot(Portal_2);
        }
    }

    void portalShoot(GameObject portal)
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal); 
            portal.transform.position = hit.point;
            portal.transform.rotation = hitObjectRotation;
            //portal.transform.rotation = new Quaternion(0,90,180,0);
        }
    }
}
