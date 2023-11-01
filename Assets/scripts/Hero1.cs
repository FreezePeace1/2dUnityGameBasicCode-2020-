﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : MonoBehaviour
{
    private const float SPEED = 50f;

  
    private void Update()
    {
     
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;

        transform.position += moveDir * SPEED * Time.deltaTime;

      
    }    
}

