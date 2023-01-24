using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTower : Tower
{
    
    protected override void DoAttack()
    {
        if (Hits[0].transform.TryGetComponent(out ObjectHealth health))
        {
            health.Attacked(attackDamage);
        }
    }
}
