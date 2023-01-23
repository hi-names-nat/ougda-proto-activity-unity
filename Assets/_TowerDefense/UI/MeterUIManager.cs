using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MeterUIManager : MonoBehaviour
{
    [SerializeField] private Scrollbar healthMeter;
    [SerializeField] private Scrollbar magicMeter;

    public void SetHealthMeter(float newSize)
    {
        healthMeter.size = newSize;
    }

    public void SetMagicMeter(float newSize)
    {
        magicMeter.size = newSize;
    }
}
