using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is called inheritance. In this case we're taking the base class of tower and telling C# that
//we want TowerTower to be everything tower is. TowerTower will have every part of Tower that is either
// public or protected (meaning that only itself and its child classes can access that thing).
public class SwordTower //1: We need something here to tell this script to use Tower as a base... What is it?
{
    
    protected void DoAttack() //2: We need to add a keyword to this function to get it behaving right... What is it? 
    {
        if (Hits[0].transform.TryGetComponent(out ObjectHealth health))
        {
            //What do we do to make the health script's health go down?
            // hint: Check the ObjectHealth script!
        }
    }
}
