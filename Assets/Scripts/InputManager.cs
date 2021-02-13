using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    public Rigidbody2D body;
    private ICommand buttonSpace;
    private ICommand buttonE;
    private ICommand buttonQ;

    Vector2 direction;
    public float speed = 3f;
    float time;
    


    void Start() {
        buttonSpace = new DashCommand(body, time, direction);
        buttonE = new AttackCommand(body);
        buttonQ = new AttackCommand(body);
    }

    void Update()
    {
        
        time = Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Me di cuenta que basta con crearlo dentro del if para mandar el time dentro de la creación del comando
            //Busque y es comun hacerlo así, no es negro
            time = Time.deltaTime;
            buttonSpace = new DashCommand(body, time, direction);
            buttonSpace.Execute();
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
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical"); 
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + direction * speed * Time.fixedDeltaTime);
    }
}