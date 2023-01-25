using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


//This is a script that gives an object a health system.
public class ObjectHealth : MonoBehaviour
{
    //The maximum health value that the object starts with
    [SerializeField] private float maxHealth = 100;
    
    //The health value that the object currently has.
    private float _currentHealth;
    
    //Allows us to run any code we set in Unity when the object is hurt.
    [SerializeField] private UnityEvent onHurt;
    
    //Allows us to run any code we set in Unity when the object dies.
    [SerializeField] private UnityEvent onDie;
    
    //This is used only on the player's instance
    [SerializeField] private MeterUIManager meterUI;

    //run before the game starts
    private void Awake()
    {
        _currentHealth = maxHealth;
        UpdatePlayerUI();
    }

    // This function will take the Damage and apply it to the current health.
    public void Attacked(float damage)
    {
        //What do we need to do here to make the health go down?
        
        if (_currentHealth <= 0) //If the current health is less or equal to zero...
        {
            //Make the player's health empty!
            UpdatePlayerUI();
            
            //We invoke the OnDie event!
            Debug.Log("Oof ouch owie my bones");
            onDie.Invoke();
        }
        else
        {
            // We didn't get hurt... Do we need to do anything?
        }
    }

    public void UpdatePlayerUI()
    {
        if (meterUI == null) return;
        meterUI.SetHealthMeter(_currentHealth / maxHealth);
    }
}
