using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, ICharacter
{
    //Utilidades
    public GameObject character;
    public Rigidbody2D body;
    Vector2 direction;
    Vector2 mouseVector;
    public Transform weaponHitBox;
    public LayerMask enemyLayer;
    //Botones
    private ICommand buttonSpace;
    private ICommand buttonE;
    private ICommand buttonQ;
    private ICommand buttonMouse0;
    private ICommand recieveDamage;
    //Estados
    public States state;
    public enum States
    {
        Normal, 
        Dashing,   
    }
    //Parametros
    public float speed;
    private float dashSpeed;
    private float dashSpeedDecrease;
    private float dashSpeedMin;
    public float timeDash;
    public float healthPlayer;


    void Awake() {
        buttonMouse0 = new AttackCommand(weaponHitBox,enemyLayer);
        speed = 3f;
        state = States.Normal;
        healthPlayer = 4;
    }

    void Update()
    {
        GetMousePos();
        switch (state)
        {
            case States.Normal:
                speed = 3f;
                dashSpeed = 6.5f;
                dashSpeedDecrease = 1f;
                dashSpeedMin = 1f;
                
                //Movimiento Y
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = 5f;
                }
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

                //Ataque
                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
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
                
                if (dashSpeed < dashSpeedMin)
                {
                    state = States.Normal;
                }
                break; 
        }    
    }

    void GetMousePos(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float finalX = mousePos.x - character.transform.position.x;
        float finalY = mousePos.y - character.transform.position.y;
        mouseVector = new Vector2(finalX,finalY);
        mouseVector = mouseVector.normalized;
        weaponHitBox.transform.position = new Vector3(mouseVector.x/2 + character.transform.position.x, mouseVector.y/2 + character.transform.position.y,0f);
    }
    

    public void RecieveDamage(float damage)
    {
        recieveDamage = new healthCommand(damage, this);
        recieveDamage.Execute();
    }

    public void Attack()
    {
        buttonMouse0.Execute(); 
    }


    /*  void OnDrawGizmosSelected()
        {
            if (weaponHitBox == null)
                return;

            Gizmos.DrawWireSphere(weaponHitBox.position, 0.4f);
        } */


}