using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface GrowthValueUpdater : IEventSystemHandler
{
    void AddGrowthValues(GrowthCategory category, int value);
}
