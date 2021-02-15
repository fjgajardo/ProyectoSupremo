using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
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
    float time;
    public States state;
    


    void Awake() {
        buttonE = new AttackCommand(body);
        buttonQ = new AttackCommand(body);
        speed = 8f;
        state = States.Normal;
    }

    void Update()
    {
        switch (state)
        {
            case States.Normal:
                direction.x = 0f;
                direction.y = 0f;

                if (Input.GetKey(KeyCode.W))
                {
                    direction.y = +1f;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    direction.y = -1f;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    direction.x = -1f;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    direction.x = +1f;
                }

                time = Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Me di cuenta que basta con crearlo dentro del if para mandar el time dentro de la creación del comando
                    //Busque y es comun hacerlo así, no es negro
                    buttonSpace = new DashCommand(body, direction, this);
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
                if (Input.GetKeyDown(KeyCode.E)&& (Input.GetKeyDown(KeyCode.Space))){
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
                buttonSpace.Execute();
                break;

        }
        
    }
}