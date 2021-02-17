using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCommand : ICommand
{
    private Rigidbody2D body;
    private Vector2 direction;    
    private float dashSpeed;
    private float dashSpeedDecrease;

    
    private InputManager input;
    private float initTime;

    public DashCommand(Rigidbody2D body, Vector2 direction, InputManager input){
        this.body = body;
        this.direction = direction;
        this.input = input;
    }

    public void Execute()
    {  
        dashSpeed = 200f;
        dashSpeedDecrease = 0.00001f;
        float dashSpeedMin = 100f;
        //float dashTime = 1f;
        

        while (true)
        {
            Debug.Log(Time.time);
            body.velocity = direction.normalized * dashSpeed;
            dashSpeed -= dashSpeedDecrease * dashSpeed;
            if (dashSpeed < dashSpeedMin)
            {
                input.state = InputManager.States.Normal;
                break;
            }
        }
    }


}