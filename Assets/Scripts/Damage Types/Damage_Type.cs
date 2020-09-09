using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Type", menuName = "RPG/Combat/Damage Type")]
public class Damage_Type : ScriptableObject
{
    [SerializeField] private new string name = "New Damage Type Name";
    [SerializeField] private Color colour = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    public string Name => name;
    public Color Colour => colour;
}
