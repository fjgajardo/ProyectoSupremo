using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCommand : ICommand
{
    private float damage;
    private Character character;

    public healthCommand(float damage, Character character)
    {
        this.damage = damage;
        this.character = character;
        
    }

    public void Execute()
    {
       character.health -= damage;
    }
    
}