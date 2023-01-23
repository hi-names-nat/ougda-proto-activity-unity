using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class Placement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer thisSprite;
    [SerializeField] private Tower tower;
    
    [SerializeField] private Color acceptableSnapColor;
    [SerializeField] private Color unacceptableSnapColor;

    public bool isInValidSpot = false;

    // Start is called before the first frame update
    private void Awake()
    {
        TryGetComponent(out tower);
    }

    // Update is called once per frame
    void Update()
    {
        //Checking against all the valid Y positions
        if (transform.position.y is -2 or 0 or 2 or 4)
        {
            thisSprite.color = acceptableSnapColor;
            isInValidSpot = true;
        }
        else
        {
            thisSprite.color = unacceptableSnapColor;
            isInValidSpot = false;
        }
    }

    //Does the stuff to finalize placing this unit.
    public void PlaceObject()
    {
        thisSprite.color = Color.white;
        tower.enabled = true;
        Destroy(this);
    }
}
