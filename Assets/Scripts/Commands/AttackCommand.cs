using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private Rigidbody2D body;
    public float attackRange;
    public Transform weaponHitBox;
    public LayerMask enemyLayer;
    


    public AttackCommand(Transform weaponHitBox, LayerMask enemyLayer){
        this.weaponHitBox = weaponHitBox;
        this.enemyLayer = enemyLayer;
        this.attackRange = 0.4f;
        
    }

    public void Execute()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weaponHitBox.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy name: "+ enemy.name);
            
        }
    }

    
}