using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCommand : ICommand
{
    private float damage;
    private Character character;
    private GameObject objectCharacter;

    public healthCommand(float damage, Character character)
    {
        this.damage = damage;
        this.character = character;
        this.objectCharacter = objectCharacter;
        
    }

    public void Execute()
    {
       character.health -= damage;
       if (character.health < 0 )
       {
       }
    }
    
}