﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;
    

    Vector3 movement;


    void Update()
    {
        //Inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space)){
            Blink(movement);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(moveSpeed * movement * Time.fixedDeltaTime);
    }

    private void Blink(Vector2 direction){
        float mag = Vector2.SqrMagnitude(direction)*3;
        if (direction.x != 0 && direction.y != 0){
            mag = 3;
        }
        direction *= mag*direction;
        Vector2 newPos = transform.position + new Vector3(direction.x, direction.y);
        if (newPos.x < leftBound)
            newPos.x = leftBound;
        if (newPos.y < lowerBound)
            newPos.y = lowerBound;
        if (newPos.x > rightBound)
            newPos.x = rightBound;
        if (newPos.y > upperBound)
            newPos.y = upperBound;
        transform.position = newPos;
    }
}
