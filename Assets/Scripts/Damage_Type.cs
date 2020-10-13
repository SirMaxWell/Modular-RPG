using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Damage Type", menuName = "RPG/Types/Damage Type")]
public class Damage_Type : ScriptableObject
{
    public enum DamType
    {
        OverTimeFlat,
        OverTimePercentage
    };

    //[SerializeField] private new string name = "New Damage Type Name";
    [SerializeField] private DamType damage_Type = new DamType();
    //public string Name => name;
    public DamType Type => damage_Type;

    public float duration;
    
}
