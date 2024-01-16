using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthValues
{
    List<int> values = new List<int>();

    public GrowthValues() {
        foreach(GrowthCategory category in Enum.GetValues(typeof(GrowthCategory))) {
            values.Add(0);
        }
        // for, i
    }

    public int GetGrowthValue(GrowthCategory category) {
        return values[(int)category];
    }

    public void SetGrowthValue(GrowthCategory category, int updatedValue) {
        values[(int)category] = updatedValue;
    }
}
