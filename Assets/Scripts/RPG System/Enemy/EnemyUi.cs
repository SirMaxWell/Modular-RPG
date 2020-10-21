using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUi : MonoBehaviour
{
    public Image EnemyHealthBar;
    public Image EnemyManaBar;

    public Image Water_Damage_Icon;
    public Image Fire_Damage_Icon;

    EnemyStats enemyStats;

    void Start()
    {
        Water_Damage_Icon.enabled = false;
        Fire_Damage_Icon.enabled = false;

        enemyStats = GetComponent<EnemyStats>();
    }
    void Update()
    {
        checkEnemyHealthUi();
        checkEnemyIconsUi();
    }

    void checkEnemyHealthUi()
    {
        EnemyHealthBar.fillAmount = (float)enemyStats.currHealth / (float)enemyStats.maxHealth;
    }
    void checkEnemyIconsUi()
    {
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
