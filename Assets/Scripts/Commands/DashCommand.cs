﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCommand : ICommand
{
    private Rigidbody2D body;
    private Vector2 direction;    
    private float dashSpeed;
    private float dashSpeedDecrease;
    private InputManager input;

    public DashCommand(Rigidbody2D body, Vector2 direction, InputManager input){
        this.body = body;
        this.direction = direction;
        this.input = input;
    }

    public void Execute()
    {  
        dashSpeed = 150f;
        dashSpeedDecrease = 0.1f;
        float dashSpeedMin = 100f;
        while (true)
        {
            dashSpeed -= dashSpeedDecrease * dashSpeed;
            body.velocity = direction.normalized * dashSpeed;
            if (dashSpeed < dashSpeedMin)
            {
                input.state = InputManager.States.Normal;
                break;
            }
        }
    }


}