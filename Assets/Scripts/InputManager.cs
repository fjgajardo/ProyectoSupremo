using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    public Rigidbody2D body;
    private ICommand buttonSpace;
    private ICommand buttonE;
    private ICommand buttonQ;

    Vector2 movement;
    public float speed = 5f;


    void Start() {
        buttonSpace = new AttackCommand(body);
        buttonE = new SpecialAttackCommand(body);
        buttonQ = new AttackCommand(body);


    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
        if (Input.GetKey(KeyCode.E)&& (Input.GetKey(KeyCode.Space))){
            buttonE.Execute();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonSpace.Execute();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            buttonQ.Execute();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            buttonE.Execute2();
        }
        else if (Input.GetKeyDown(KeyCode.E)&& (Input.GetKeyDown(KeyCode.Space))){
            buttonE.Execute();
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }
}