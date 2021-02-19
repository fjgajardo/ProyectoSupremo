using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float health;
    public float damage;
    public ICommand recieveDamage;

    public virtual void RecieveDamage(float damage)
    {
        recieveDamage = new healthCommand(damage, this);
        recieveDamage.Execute();
    }
    
    public abstract void Attack();
}
