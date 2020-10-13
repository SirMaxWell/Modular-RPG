using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spell : ScriptableObject

{
    [Header("Details")]
    public string spellName = "New Spell";
    public GameObject spellPrefab = null;

    public SpellType spellType = new SpellType();
    public EleType elemental_Type = new EleType();

    [Space]
    public float ManaCost;
    public float ProjectileSpeed;
    [Space]
    
    [Header("Phyical Blast Damage")]
    public int MaxPotentialImpactDamage; [Tooltip("How much the attack could potentially do")]
    public int minPotentialImpactDamage; [Tooltip("Calculated by halving the Max Impact Damage")]
    public int finalImpactDamage; [Tooltip("Random range between Max and Min Impact Damage")]
    [Space]
    [Header("Elemental Damage")]
    public int MaxPotentialElementalDamage; [Tooltip("How much the attack could potentially do")]
    public int Duration; [Tooltip("How long the attack lasts for")]
    public int finalElementDamage; [Tooltip("How much the attack will do over time")]
    [Space]

    [HideInInspector]
    public float finalValue;



    [HideInInspector]
    public DamType damage_Type = new DamType();
    public enum SpellType
    { None, Blast, Status_Effect }
    public enum EleType
    { Fire, Water, Posion }
    
    public enum DamType
    { OverTimeFlat, OverTimePercentage }

   



}
