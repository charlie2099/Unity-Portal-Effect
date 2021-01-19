using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPortals : MonoBehaviour
{
    // takes a reference to the two portal gameobjects
    public GameObject first_portal;
    public GameObject second_portal;
    GameObject player_camera;

    const int LEFT_CLICK = 0;
    const int RIGHT_CLICK = 1;

    void Start()
    {
        player_camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(LEFT_CLICK))
        {
            shootPortal(first_portal);
        }

        else if (Input.GetMouseButtonDown(RIGHT_CLICK))
        {
            shootPortal(second_portal);
        }
    }

    void shootPortal(GameObject portal)
    {
        int center_x = Screen.width / 2;
        int center_y = Screen.height / 2;
        Ray ray = player_camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(center_x,center_y));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Quaternion rotationOfHitObject = Quaternion.LookRotation(hit.normal);
            portal.transform.position = hit.point;
            portal.transform.rotation = rotationOfHitObject;
        }
    }
}
