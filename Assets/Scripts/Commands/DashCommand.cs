using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCommand : ICommand
{
    private Rigidbody2D body;
    private float time;
    private Vector2 direction;
    
    private float dashSpeed;
    private float startDashTime = 0.1f;
    private float dashTime;
    private IEnumerator coroutine;

    public DashCommand(Rigidbody2D body, float time, Vector2 direction){
        this.body = body;
        this.time = time;
        this.direction = direction;
        this.dashTime = startDashTime;
        dashSpeed = 50f;
    }

    public void Execute()
    {  
        //Prueba esto con drag, los valores que importan son StartDashTime y dashSpeed
        while (dashTime > 0)
        {
            if (body.velocity == Vector2.zero)
            {
                body.AddForce(direction*dashSpeed);
            }
            dashTime -= Time.deltaTime;
        } 
        dashTime = startDashTime;
        body.velocity = Vector2.zero;
        

    }


}