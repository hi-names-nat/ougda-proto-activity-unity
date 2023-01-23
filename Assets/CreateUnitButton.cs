using System.Collections;
using System.Collections.Generic;
using _TowerDefense.Player;
using UnityEngine;

public class CreateUnitButton : MonoBehaviour
{
    [SerializeField] private Tower unit;
    [SerializeField] private float cost = 15;

    [SerializeField] private PlayerManager playerManager;
    
    public void CreateUnit()
    {
        playerManager.CreateAndAttachUnit(unit.gameObject, cost);
    }
}
