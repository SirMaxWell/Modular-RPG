using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "RPG/Types/Element Type")]
public class ElementalType : ScriptableObject
{
    
    public enum EleType
    {
        Fire,
        Water,
        Posion
    };
    

     private new string name = "New Element Name";
     private Color colour = new Color(0.0f, 0.0f, 0.0f, 0.0f);
     public EleType elemental_Type = new EleType();
     private float minElementalDamage = 0.0f;
     private float maxElementalDamage = 0.0f;

    public string Name => name;
    public Color Colour => colour;
   // public EleType Type => elemental_Type;
    public float MinElementalDamage => minElementalDamage;
    public float MaxElementalDamage => maxElementalDamage;


    
    
    
}
