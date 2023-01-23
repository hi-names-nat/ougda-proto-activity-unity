using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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

    private void Awake()
    {
        _currentHealth = maxHealth;
        UpdatePlayerUI();
    }

    // This function will take the Damage and apply it to the current health.
    public void Attacked(float damage)
    {
        _currentHealth -= damage;
        
        if (_currentHealth <= 0) //If the current health is less or equal to zero...
        {
            //We invoke the OnDie event!
            onDie.Invoke();
        }
        else
        {
            //If not we invoke the onHurt event.
            onHurt.Invoke();
        }
    }

    public void UpdatePlayerUI()
    {
        if (meterUI == null) return;
        meterUI.SetHealthMeter(_currentHealth / maxHealth);
    }
}
