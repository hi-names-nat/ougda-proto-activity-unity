//Don't worry about this script.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MeterUIManager : MonoBehaviour
{
    //A reference to our health bar
    [SerializeField] private Scrollbar healthMeter;
    //a reference to our magika meter
    [SerializeField] private Scrollbar magicMeter;

    //A function that sets the health meter % for us/
    public void SetHealthMeter(float newSize)
    {
        healthMeter.size = newSize;
    }

    //A function that sets the magic meter % for us/
    public void SetMagicMeter(float newSize)
    {
        magicMeter.size = newSize;
    }
}
