using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCommand : ICommand
{
    private float damage;
    private ICharacter character;

    public healthCommand(float damage, ICharacter character){
        this.damage = damage;
        this.character = character;
        
    }

    public void Execute()
    {
        character.healthPlayer -= damage;
    }
    
}