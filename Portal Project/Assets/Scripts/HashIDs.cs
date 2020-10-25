using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int dyingState;
    public int deadBool;
    public int walkState;
    public int speedFloat;
    public int backwardsBool;
    public int runBool;
    public int jumpBool;
    public int leverBool;

    private void Awake()
    {
        dyingState = Animator.StringToHash("Base Layer.Dying");
        deadBool = Animator.StringToHash("Dead");
        walkState = Animator.StringToHash("Walk");
        speedFloat = Animator.StringToHash("Speed");
        backwardsBool = Animator.StringToHash("Backwards");
        runBool = Animator.StringToHash("Run");
        jumpBool = Animator.StringToHash("Jump");
        leverBool = Animator.StringToHash("Lever");
    }
}