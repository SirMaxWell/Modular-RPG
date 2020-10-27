using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUi : MonoBehaviour
{
    
    public Image EnemyHealthBar;    // Health bar over enemy's head
    public Image EnemyManaBar;      //  not currently using 

    public Image Water_Damage_Icon; // Water Damage that appears over enemy's head
    public Image Fire_Damage_Icon; // Fire Damage that appears over enemy's head

    EnemyStats enemyStats;

    void Start()
    {
        Water_Damage_Icon.enabled = false; // sets them to false to begin
        Fire_Damage_Icon.enabled = false;   // sets them to false to begin

        enemyStats = GetComponent<EnemyStats>(); // gets enemey stats 
    }
    void Update()
    {
        checkEnemyHealthUi(); // constantly updates health
        checkEnemyIconsUi(); // constantly updates Icon Ui
    }

    void checkEnemyHealthUi()
    {
        EnemyHealthBar.fillAmount = (float)enemyStats.currHealth / (float)enemyStats.maxHealth; // changes the fill amount for the hp bar
    }
    void checkEnemyIconsUi()
    {
        // changes the icons on and off
        if(enemyStats.isOnFire == true)
        {
            Fire_Damage_Icon.enabled = true;
        }
        else if(enemyStats.isOnFire == false)
        {
            Fire_Damage_Icon.enabled = false;
        }
        if(enemyStats.IsWet == true)
        {
            Water_Damage_Icon.enabled = true;
        }
        else if (enemyStats.IsWet == false)
        {
            Water_Damage_Icon.enabled = false;
        }
    }


}
