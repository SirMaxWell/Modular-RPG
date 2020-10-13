using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Physical Type", menuName = "RPG/Types/Physical Type")]
public class PhysicalType : ScriptableObject
{
    public enum PhyType
    {
        Basic,
        Impact
    }
    //public float MinRange;
    //public float MaxRange;
    //public float Value;
    //public PhyType Type;

    [SerializeField] private new string name = "New Physical Name";
    [SerializeField] private PhyType physical_Type = new PhyType();

    public string Name => name;
    public PhyType Type => physical_Type;

    


   
/*
    void CalcDamage()
    {
        float finalValue = Value;
        for (int i = 0; i < physicalTypes.Count; i++)
        {
            PhysicalType physical = physicalTypes[i];
            if (physical.Type == PhysicalType.PhyType.Basic)
            {
                finalValue += physical.Value;
            }
            else if (physical.Type == PhysicalType.PhyType.Impact)
            {
                //finalValue = Random.Range(5, 10);
            }
        }
    }
    */
}
