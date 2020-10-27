using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpellCreator : EditorWindow
{
    
    static void Init()
    {
        SpellCreator spellWindow = (SpellCreator)CreateInstance(typeof(SpellCreator));
        spellWindow.Show();
    }
    Spell tempSpell = null;
    RPGManager rpgManager = null;
    
    


    void OnGUI() // Shows gui for the user to use and interact with
    {
        if(rpgManager = null)
        {
            rpgManager = GameObject.Find("RPGManager").GetComponent<RPGManager>();
        }
        if(tempSpell)
        {
            EditorGUILayout.LabelField("Spell Creator");
            tempSpell.spellName = EditorGUILayout.TextField("Spell Name:", tempSpell.spellName);
            tempSpell.spellPrefab = (GameObject)EditorGUILayout.ObjectField("Spell Prefab:", tempSpell.spellPrefab, typeof(GameObject), false);
            tempSpell.elemental_Type = (Spell.EleType)EditorGUILayout.EnumPopup("Elemental Type:", tempSpell.elemental_Type); // after picking a type the other information will appear
            tempSpell.spellType = (Spell.SpellType)EditorGUILayout.EnumPopup("Spell Type:", tempSpell.spellType); // after picking a type the other information will appear
            if(tempSpell.elemental_Type == Spell.EleType.Fire)
            {
                if (tempSpell.spellType == Spell.SpellType.Blast)
                {
                    
                    tempSpell.MaxPotentialImpactDamage = EditorGUILayout.IntField("Max Impact Damage:", tempSpell.MaxPotentialImpactDamage);
                    EditorGUILayout.HelpBox("Max Impact Damage is what the attack could potentially do, isn't always the same amount", MessageType.Info); // help box
                    EditorGUILayout.Space();
                    tempSpell.MaxPotentialElementalDamage = EditorGUILayout.IntField("Max Elemental Damage:", tempSpell.MaxPotentialElementalDamage);
                    tempSpell.Duration = EditorGUILayout.IntField("Duration:", tempSpell.Duration);
                    tempSpell.ManaCost = EditorGUILayout.FloatField("Mana Cost:", tempSpell.ManaCost);
                    tempSpell.ProjectileSpeed = EditorGUILayout.FloatField("Projectile Speed:", tempSpell.ProjectileSpeed);
                }
                if (tempSpell.spellType == Spell.SpellType.Status_Effect)
                {
                    tempSpell.MaxPotentialElementalDamage = EditorGUILayout.IntField("Max Elemental Damage:", tempSpell.MaxPotentialElementalDamage);
                    tempSpell.Duration = EditorGUILayout.IntField("Duration:", tempSpell.Duration);
                    tempSpell.ManaCost = EditorGUILayout.FloatField("Mana Cost:", tempSpell.ManaCost);
                    tempSpell.ProjectileSpeed = EditorGUILayout.FloatField("Projectile Speed:", tempSpell.ProjectileSpeed);
                }
            }
            else if(tempSpell.elemental_Type == Spell.EleType.Water)
            {
                if (tempSpell.spellType == Spell.SpellType.Blast)
                {
                    tempSpell.MaxPotentialImpactDamage = EditorGUILayout.IntField("Max Impact Damage:", tempSpell.MaxPotentialImpactDamage);
                    tempSpell.Duration = EditorGUILayout.IntField("Duration:", tempSpell.Duration);
                    tempSpell.ManaCost = EditorGUILayout.FloatField("Mana Cost:", tempSpell.ManaCost);
                    tempSpell.ProjectileSpeed = EditorGUILayout.FloatField("Projectile Speed:", tempSpell.ProjectileSpeed);
                }
                if(tempSpell.spellType == Spell.SpellType.Status_Effect)
                {
                    tempSpell.Duration = EditorGUILayout.IntField("Duration:", tempSpell.Duration);
                    tempSpell.ManaCost = EditorGUILayout.FloatField("Mana Cost:", tempSpell.ManaCost);
                    tempSpell.ProjectileSpeed = EditorGUILayout.FloatField("Projectile Speed:", tempSpell.ProjectileSpeed);
                }
            }
            else if (tempSpell.elemental_Type == Spell.EleType.Posion)
            {

            }
            
            
            
        }

        EditorGUILayout.Space();

        if (tempSpell == null)
        {
            if (GUILayout.Button("Create Spell"))
            {
                tempSpell = CreateInstance<Spell>();
            }
        }
        else
        {
            if (GUILayout.Button("Create Scriptable Object"))
            {
                AssetDatabase.CreateAsset(tempSpell, "Assets/Scripts/RPG System/Spells/" + tempSpell.spellName + ".asset");
                AssetDatabase.SaveAssets();
                rpgManager.spellList.Add(tempSpell);
                Selection.activeObject = tempSpell;
                tempSpell = null;
            }
            if (GUILayout.Button("Reset"))
            {
                Reset();
            }
            if(GUILayout.Button("Close"))
            {
                Exit();
            }
        }
        
        // Resets all values
        void Reset()
        {
            if(tempSpell)
            {
                tempSpell.spellName = "New Spell";
                tempSpell.spellPrefab = null;
                tempSpell.spellType = Spell.SpellType.None;
                tempSpell.elemental_Type = Spell.EleType.None;
                tempSpell.MaxPotentialImpactDamage = 0;
                tempSpell.MaxPotentialElementalDamage = 0;
                tempSpell.Duration = 0;
                tempSpell.ProjectileSpeed = 0;

                tempSpell.ManaCost = 0;
            }
        }
        void Exit()
        {
            this.Close();
        }
    }
}


//public enum SpellType
//{ Blast, Status_Effect }
//public enum EleType
//{ Fire, Water, Posion }
//public SpellType spellTypeOptions;
//public EleType elementalTypeOptions;