using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] private ObjectHealth playerHealth;
    [SerializeField] private float harm;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy e))
        {        
            playerHealth.Attacked(harm);
            Destroy(e.gameObject);
        }
    }
}
