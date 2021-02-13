using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private Rigidbody2D body;

    public AttackCommand(Rigidbody2D body){

        this.body = body;
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}