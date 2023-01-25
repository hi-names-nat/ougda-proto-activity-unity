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
    //Something is wrong with our variables, but it will take a project-centric approach to figure out what...
    //hint: does anything inherit this script?
    //Inheritance is using a class as a basis for another. Are there any scripts that might use this one as a basis?

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
    private RaycastHit2D[] Hits;
    //The number of enemies we hit
    private int NumHit;

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
        
        //We want to do our raycast so that we get what we're going to hit... How do we do that?
        //We also want to make sure we use our contactFilter or else we're just going to hit the background 
        //when we try
        //hint: look at ths: https://docs.unity3d.com/2021.3/Documentation/ScriptReference/Physics2D.Raycast.html
        //  specfically the second one.
        
        //here's a visualization of the ray we're going to cast, hpefully it helps.
        Debug.DrawRay(transform.position, Vector2.right * attackRange, Color.green);
        print(NumHit);
        if (NumHit == 0) return;
        
        //We need to do our animation...
        
        //Reset our timer
        _currentCooldownTime = attackCooldownTime;
        
        //Have our specific tower do our attack
        DoAttack();

    }

    protected abstract void DoAttack();
}
