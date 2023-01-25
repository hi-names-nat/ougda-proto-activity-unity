using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class Placement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer thisSprite;
    [SerializeField] private Tower tower;
    
    //We want to be able to access these in Unity's inspector.. How do we do that
    //Hint: it's everywhere!!!
    private Color acceptableSnapColor;
    private Color unacceptableSnapColor;

    public bool isInValidSpot = false;

    // Start is called before the first frame update
    private void Awake()
    {
        acceptableSnapColor = Color.green;
        unacceptableSnapColor = Color.red;
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
