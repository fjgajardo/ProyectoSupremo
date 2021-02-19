using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , ICharacter
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
    }

    void FixedUpdate()
    {   
    
    }

    void GetPlayerPos(){
        //Recibir ubicación del jugador
    }
    
    public void RecieveDamage(float damage)
    {
        /* recieveDamage = new healthCommand(damage);
        recieveDamage.Execute(); */
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }
}