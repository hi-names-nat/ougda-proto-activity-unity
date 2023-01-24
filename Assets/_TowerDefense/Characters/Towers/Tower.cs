using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

//This is the base script for our tower class
[RequireComponent(typeof(ObjectHealth))]
public abstract class Tower : MonoBehaviour
{
    //Time between each tower action
    [SerializeField] protected float attackCooldownTime = 5f;
    //The current state of cooldown
    private float _currentCooldownTime = -1;
    
    //The range of the tower's attack
    [SerializeField] protected float attackRange = 3f;
    //The damage that the tower deals. 
    [SerializeField] protected float attackDamage = 100;
    //The number of enemies that the tower can hit at once
    [SerializeField] protected int numberHittableAtOnce = 3;

    //The animator attached.
    private Animator _animator;

    //When hitting enemies, the enemies we hit
    protected RaycastHit2D[] Hits;
    //The number of enemies we hit
    protected int NumHit;

    private void Awake()
    {
        Hits = new RaycastHit2D[numberHittableAtOnce];
        _animator = GetComponent<Animator>();
        _currentCooldownTime = attackCooldownTime;

    }

    // Update is called once per frame
    void Update()
    {
        //Update our cooldown time
        _currentCooldownTime -= Time.deltaTime;

        //We're done if the timer isn't 0
        if (_currentCooldownTime > 0) return;
        
        //Setup a contact filter, essentially what the raycast can and can't hit
        var contactFilter = new ContactFilter2D
        {
            //We set a specific layer to only hit that layer
            layerMask = LayerMask.GetMask("Enemies")
        };
        
        //Do our raycast
        NumHit = Physics2D.Raycast(transform.position, Vector2.right, contactFilter, Hits, attackRange);
        Debug.DrawRay(transform.position, Vector2.right * attackDamage, Color.green);
        print(NumHit);
        if (NumHit == 0) return;
        
        //Do our animation
        _animator.SetTrigger("Attack");
        
        //Reset our timer
        _currentCooldownTime = attackCooldownTime;
        
        //Have our specific tower do our attack
        DoAttack();

    }

    protected abstract void DoAttack();
}
