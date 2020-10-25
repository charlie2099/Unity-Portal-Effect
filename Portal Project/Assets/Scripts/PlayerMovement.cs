using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 3.0f;

    private Animator anim;
    private HashIDs hash;
    private float elapsedTime = 0;
    private bool noBackMov = true;
    private GameObject Player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //anim.SetLayerWeight(1, 1f);

        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

        Player = GameObject.Find("Ethan");
    }

    private void FixedUpdate()
    {
        // if I put the code within Update in here, the rotation will keep looping! (???)
        //Debug.Log(Player.transform.parent);
        //Debug.Log(Player.GetComponent<PlayerMovement>().enabled);
    }

    private void Update()
    {
        float v = Input.GetAxis("Vertical");
        MovementManagement(v);

        elapsedTime += Time.deltaTime;

        
    }

    void MovementManagement(float vertical)
    {

        //if (vertical > 1) // if going forward
        //{
        //    anim.SetFloat(hash.speedFloat, 2f, speedDampTime, Time.deltaTime);
        //    //Debug.Log("Run");
        //}

        if (vertical > 0) // if going forward
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", false);
            noBackMov = true;

            Rigidbody ourBody = this.GetComponent<Rigidbody>();
            Vector3 moveFor = new Vector3(0.0f, 0.0f, 0.020f); // speed
            moveFor = ourBody.transform.TransformDirection(moveFor);
            ourBody.transform.position += moveFor;
        }

        if (vertical < 0) // if going backward
        {
            if (noBackMov == true)
            {
                elapsedTime = 0;
                noBackMov = false;
            }

            anim.SetFloat(hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backwards", true);

            Rigidbody ourBody = this.GetComponent<Rigidbody>();
            Vector3 moveBack = new Vector3(0.0f, 0.0f, -0.020f); // speed
            moveBack = ourBody.transform.TransformDirection(moveBack);
            ourBody.transform.position += moveBack;
        }

        if (vertical == 0) // if idle
        {
            anim.SetFloat(hash.speedFloat, 0.01f);
            anim.SetBool(hash.backwardsBool, false);
            noBackMov = true;
        }

        // CONTROLS

        if (Input.GetKey(KeyCode.LeftShift)) // RUN
        {
            anim.SetBool("Run", true);
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift)) // RUN UP
        {
            anim.SetBool("Run", false);
        }


        if (Input.GetKey(KeyCode.Space)) // JUMP
        {
            //anim.SetBool("Jump", true);
            anim.Play("HumanoidCrouchWalkLeft");
        }


        if (Input.GetKey(KeyCode.A)) // LEFT DOWN
        {
            anim.SetBool("LeftTurn", true);
        }

        else if (Input.GetKeyUp(KeyCode.A)) // LEFT UP
        {
            anim.SetBool("LeftTurn", false);
        }


        if (Input.GetKey(KeyCode.D)) // RIGHT DOWN
        {
            anim.SetBool("RightTurn", true);
        }

        else if (Input.GetKeyUp(KeyCode.D)) //RIGHT UP
        {
            anim.SetBool("RightTurn", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
    }

    /*void Rotating(float mouseXInput)
    {
        //access the avatar's rigidbody 
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        //first check to see if we have rotation data that needs to be applied
        if (mouseXInput != 0)
        {
            //if so we use mouseX value to create a Euler angle which provides rotation in the Y axis
            //which is then turned to a Quaternion
            Quaternion deltaRotation = Quaternion.Euler(0f, mouseXInput * sensitivityX, 0f);

            //and then applied to turn the avatar via the rigidbody
            ourBody.MoveRotation(ourBody.rotation * deltaRotation);
        }
    }*/
}


//using UnityEngine;
//using System.Collections;

//public class PlayerMovement : MonoBehaviour
//{
//    public float speedDampTime = 0.01f;
//    private float moveSpeed = 100.0f;
//    private float rotateSpeed = 2.0f;
//    private Animator anim;

//    // Use this for initialization
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        if (Input.GetKey("w")) // forwards
//        {
//            transform.Translate((Vector3.forward) * moveSpeed * Time.deltaTime);
//            Debug.Log("Pressing W Key");
//        }

//        if (Input.GetKey("s")) // backwards
//        {
//            transform.Translate((Vector3.back) * moveSpeed * Time.deltaTime);
//            anim.SetBool("Backwards", true);
//        }

//        if (Input.GetKey("a")) // left
//        {
//            transform.Rotate((Vector3.down) * rotateSpeed);
//            //transform.Translate((Vector3.left)* moveSpeed * Time.deltaTime);
//            anim.SetBool("LeftTurn", true);
//            Debug.Log("Pressing A Key");
//        }

//        if (Input.GetKeyUp("a")) // left UP
//        {
//            anim.SetBool("LeftTurn", false);
//        }

//        //if (Input.GetKey("d")) // right
//        //{
//        //    transform.Rotate((Vector3.up) * rotateSpeed);
//        //    //transform.Translate((Vector3.right)* moveSpeed * Time.deltaTime);
//        //    anim.SetBool("RightTurn", true);
//        //    Debug.Log("Pressing D Key");
//        //}

//        //if (Input.GetKeyUp("d")) // right UP
//        //{
//        //    anim.SetBool("RightTurn", false);
//        //}

//        if (Input.GetKey(KeyCode.D)) 
//        {
//            anim.SetBool("RightTurn", true);                                
//        }

//        else if (Input.GetKeyUp(KeyCode.D)) 
//        {
//            anim.SetBool("RightTurn", false);
//        }



//            if (Input.GetKey("left shift") && Input.GetKey("w"))
//        {
//            moveSpeed = 20.0f;
//            Debug.Log("Left Shift");
//        }
//        else
//            moveSpeed = 10.0f;
//    }
//}


