using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RPG_SystemCreator : EditorWindow
{
    
    
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
            spellWindow.Show(); 
        }
        if(GUILayout.Button("Weapons"))
        {
            WeaponCreator weaponWindow = (WeaponCreator)CreateInstance(typeof(WeaponCreator));
            weaponWindow.Show(); 
        }
    }

}
