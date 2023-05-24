using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController controller;
    Animator animator;

    //Input variables
    float mouseInputX;
    float mouseSens = 5f;
    float horzAxis;
    float vertAxis;

    //Character controlls
    float rotationX = 0f;
    float rotationY = 0f;
    Vector3 velocity;
    float moveSpeed = 1f;

    bool playingSound = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Inputs();
        HorizontalCamera();
        ApplyMovement();
    }

    void Inputs()
    {
        mouseInputX = Input.GetAxis("Mouse X") * mouseSens;
        horzAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");
    }

    //only deals with the X axis since it also rotates the player
    //another script attached to the camera deals with the VERT movement
    void HorizontalCamera() 
    {
        rotationX = mouseInputX;
        transform.Rotate(Vector3.up * rotationX * 2);
    }

    void ApplyMovement()
    {
        controller.Move(velocity * Time.deltaTime);
        Vector3 move = (transform.right * horzAxis) + (transform.forward * vertAxis);
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Animation
        animator.SetBool("walkingFront", Input.GetKey(KeyCode.W));
        animator.SetBool("walkingLeft", Input.GetKey(KeyCode.A));
        animator.SetBool("walkingRight", Input.GetKey(KeyCode.D));
        animator.SetBool("walkingBack", Input.GetKey(KeyCode.S));

        //Sound
        /*
        if(horzAxis == 0 && vertAxis == 0)
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("Footstep");
        else
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Footstep");*/

        /*
        if (horzAxis == 0 && vertAxis == 0)
        {
            print("stopped");
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("Footstep");
        }
        else
        {
            print("moving");
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Footstep");
        }*/

        if ((horzAxis != 0 || vertAxis != 0) && playingSound == false)
        {
            
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().PlayAudio("Footstep");
            playingSound = true;
            //print("moving");
        }


        if(horzAxis == 0 && vertAxis == 0)
        {
            playingSound = false;
            //print("stopped");
            GameObject.Find("TheAudioManager").GetComponent<TheAudioManager>().StopAudio("Footstep");
        }


    }
}
