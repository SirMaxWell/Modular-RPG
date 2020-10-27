using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStats 
{
    // Any Base stats that either players or enemies will have like statmia/HP/Mana etc
    [SerializeField]
    public float BaseValue;
    // private List<StatModifier> statModifiers;
    
    
    public float getValue()
    {
        return BaseValue;
    }
    
    

}
