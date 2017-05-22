﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;
//using System.Math;

public class PlayerMovementController : MonoBehaviour {
    public float speed = 1.0f;
    public AudioSource source3;
    public AudioSource source4;
    private float x;
    private Vector3 movement;
    private Rigidbody rb;
    //public float jumpHeight;
    public float max_speed;
    public float min_speed;
    public float reduce;
    




    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement.y = 0.0f;

        if (System.Math.Abs(moveHorizontal) > 0 & System.Math.Abs(moveVertical) > 0){
            if (moveHorizontal >0.0f){
                movement.x = speed/reduce;
            } else if (moveHorizontal < 0.0f){
                movement.x = -speed/reduce;
            } else{
                movement.x = 0.0f;
            }
            if (moveVertical>0.0f){
                movement.z = speed/reduce;
            } else if (moveVertical<0.0f){
                movement.z = -speed/reduce;
            } else{
                movement.z = 0.0f;
            }
        } else {
            if (moveHorizontal >0.0f){
                movement.x = speed;
            } else if (moveHorizontal < 0.0f){
                movement.x = -speed;
            } else{
                movement.x = 0.0f;
            }
            if (moveVertical>0.0f){
                movement.z = speed;
            } else if (moveVertical<0.0f){
                movement.z = -speed;
            } else{
                movement.z = 0.0f;
            }
        }

        /*if (moveHorizontal < min_speed){
            movement.x = moveHorizontal + (min_speed - moveHorizontal);
        }
        if (moveVertical < min_speed){
            movement.z = moveVertical + (min_speed - moveHorizontal);
        }

        if (moveHorizontal > max_speed){
            movement.x = max_speed;
        }else if (moveHorizontal < -max_speed){
            movement.x = -max_speed;
        }else{
            movement.x = moveHorizontal;}

        if (moveVertical > max_speed){
            movement.z = max_speed;
        }else if (moveVertical < -max_speed){
            movement.z = -max_speed;
        }else{
            movement.z = moveVertical;}
        */
        rb.AddForce (movement); 
    }

    private void Update() {
        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");

        //var newPosition = transform.position;
		//newPosition += new Vector3(horizontal, 0.0f, vertical).normalized * speed * Time.deltaTime;
		//transform.position = newPosition;

        Turn();
        /*if (Input.GetKeyDown(KeyCode.F)){
            if (rb.transform.position.y <= 5){
                rb.AddForce(0,jumpHeight,0);    
            }
        }*/
        if(Input.GetMouseButton(0)) {
            animator.SetTrigger("Attacking");
            x = UnityEngine.Random.Range(0, 2);
            if (x < 1){
                source3.Play();
            } else{
                source4.Play();
            }
        }
    }

    private void Turn() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit;
        if (Physics.Raycast(camRay, out mouseHit)) {

            Vector3 playerToMouse = mouseHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = newRotatation;
        }
    }
}
