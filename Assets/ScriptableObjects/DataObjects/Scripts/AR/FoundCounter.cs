using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundCounter
{
    public int actualFoundCount { get; private set; }
    public int requiredFoundCount { get; private set; }
    public bool hasBeenTriggered { get; private set; }


    public FoundCounter()
    {
        actualFoundCount = 0;
        requiredFoundCount = 1;
    }

    public void IncrementRequired()
    {
        requiredFoundCount++;
    }

    public void IncrementActual()
    {
        actualFoundCount++;
    }

    public void ResetActual()
    {
        actualFoundCount = 0;
    }

    public void FoundRequiredAmount()
    {
        hasBeenTriggered = true;
    }
}
