using System.Collections;
using System.Collections.Generic;
using _TowerDefense.Player;
using UnityEngine;

// This is a helper script to get our data to our playermanager.
public class CreateUnitButton : MonoBehaviour
{
    //The unit that this button will create
    [SerializeField] private Tower unit;
    //The cost of creating a unit.
    [SerializeField] private float cost = 15;

    //a reference to our player manager
    [SerializeField] private PlayerManager playerManager;
    
    //a helper function so our button can actually call this function.
    public void CreateUnit()
    {
        playerManager.CreateAndAttachUnit(unit.gameObject, cost);
    }
}
