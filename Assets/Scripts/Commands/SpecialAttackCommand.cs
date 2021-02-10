using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackCommand : ICommand
{
    private Rigidbody2D body;

    public SpecialAttackCommand(Rigidbody2D body){

        this.body = body;
    }

    public void Execute()
    {
        Debug.Log("AtaqueSecreto");
    }

    public void Execute2()
    {
        Debug.Log("SpecialAttack");
    }

}