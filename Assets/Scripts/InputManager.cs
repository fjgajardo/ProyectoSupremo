﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    public GameObject character;
    public Rigidbody2D body;
    private ICommand buttonSpace;
    private ICommand buttonE;
    private ICommand buttonQ;
    public enum States
    {
        Normal, 
        Dashing,   
    }
    Vector2 direction;
    public float speed;
    private float dashSpeed;
    private float dashSpeedDecrease;
    private float dashSpeedMin;
    public States state;
    public float timeDash;
    


    void Awake() {
        buttonE = new AttackCommand(body);
        buttonQ = new AttackCommand(body);
        speed = 3f;
        state = States.Normal;
    }

    void Update()
    {
        switch (state)
        {
            case States.Normal:
                dashSpeed = 6.5f;
                dashSpeedDecrease = 1f;
                dashSpeedMin = 1f;
                
                //Movimiento Y
                if (Input.GetKey(KeyCode.W))
                {
                    direction.y = +1f;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    direction.y = -1f;
                }
                else 
                {
                    direction.y = 0f;
                }
                //Movimiento X
                if (Input.GetKey(KeyCode.A))
                {
                    direction.x = -1f;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    direction.x = +1f;
                }
                else 
                {
                    direction.x = 0f;
                }

                //Dash
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    timeDash = Time.time + 0.15f;
                    state = States.Dashing;   
                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    buttonQ.Execute();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    buttonE.Execute();
                }
                break;
            case States.Dashing:
                break;
        }
        


    }

    void FixedUpdate()
    {   
        switch (state)
        {
            case States.Normal:
                direction = direction.normalized * speed;
                body.velocity = direction;
                break;

            case States.Dashing:
                body.velocity = direction.normalized * dashSpeed;
                if (Time.time > timeDash)
                {
                    dashSpeed -= dashSpeedDecrease;
                }
                Debug.Log(Time.time + ": Velocidad: " + body.velocity);
                if (dashSpeed < dashSpeedMin)
                {
                    state = States.Normal;
                }

                break; 
        }
        
    }
}