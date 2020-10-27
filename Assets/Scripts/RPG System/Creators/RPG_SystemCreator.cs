using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RPG_SystemCreator : EditorWindow
{   
    // Creates a window for user to pick what they would like to create 
    public SpellCreator spellCreator;
    public WeaponCreator weaponCreator;
    [MenuItem("RPG System/RPG Creator")]
    static void Init()
    {
        RPG_SystemCreator rpgWindow = (RPG_SystemCreator)CreateInstance(typeof(RPG_SystemCreator));
        rpgWindow.Show();
    }
    private void OnGUI()
    {
        if(GUILayout.Button("Spells"))
        {
            SpellCreator spellWindow = (SpellCreator)CreateInstance(typeof(SpellCreator));
            spellWindow.Show(); // shows the spell creator window
        }
        if(GUILayout.Button("Weapons - WIP"))
        {
            WeaponCreator weaponWindow = (WeaponCreator)CreateInstance(typeof(WeaponCreator));
            weaponWindow.Show(); // shows the Weapons creator window 
        }
    }

}
