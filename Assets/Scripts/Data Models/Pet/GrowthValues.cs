using System;
using System.Collections.Generic;

public class GrowthValues
{
    private List<int> _values = new List<int>();

    public GrowthValues() {
        for (int i = 0; i < Enum.GetValues(typeof(GrowthCategory)).Length; i++) {
            _values.Add(0);
        }
    }

    public int GetGrowthValue(GrowthCategory category) {
        return _values[(int)category];
    }

    public void SetGrowthValue(GrowthCategory category, int updatedValue) {
        _values[(int)category] = updatedValue;
    }    
}
