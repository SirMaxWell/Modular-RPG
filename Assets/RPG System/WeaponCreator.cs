using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponCreator : EditorWindow
{
    //[MenuItem("RPG System/RPG Creator/Weapon")]
    static void Init()
    {
        WeaponCreator weaponWindow = (WeaponCreator)CreateInstance(typeof(WeaponCreator));
        weaponWindow.Show();
    }
}
