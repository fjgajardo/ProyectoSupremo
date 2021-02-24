using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //Utilidades
    public GameObject objeto;

    //Botones

    //Estados
    public States state;
    public enum States
    {
        Normal, 
        Dashing,   
    }
    //Parametros



    void Awake() {
        state = States.Normal;
        health = 100f;
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
    

    public override void RecieveDamage(float damage)
    {
        recieveDamage = new healthCommand(damage, this);
        recieveDamage.Execute();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}