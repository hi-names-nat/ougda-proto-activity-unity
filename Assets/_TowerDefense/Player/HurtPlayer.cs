using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

//This is a script that informs the player's health script that it's taken damage.
public class HurtPlayer : MonoBehaviour
{
    // A reference to our player's health.
    [SerializeField] private ObjectHealth playerHealth;
    
    //how much we hurt the player when an enemy gets past
    [SerializeField] private float harm =  10;
    
    //This script is run when something (i.e. an enemy) enters the collider.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy e))
        {
            playerHealth.Attacked(harm);
            Destroy(e.gameObject);
        }
    }
}
