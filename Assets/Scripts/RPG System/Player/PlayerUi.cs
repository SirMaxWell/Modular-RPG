using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;

    public Image armor_Icon;
    public Image armor_Lvl2_Icon;
    public bool isArmorlvl1On;
    public bool isArmorlvl2On;

    public Image Fire_Resis_Icon;
    public Image Fire_Resis_Lvl2_Icon;
    public bool isFirelvl1On;
    public bool isFirelvl2On;

    public Image Water_Damage_Icon;
    public Image Fire_Damage_Icon;

    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        armor_Icon.enabled = false;
        armor_Lvl2_Icon.enabled = false;
        Fire_Resis_Icon.enabled = false;
        Fire_Resis_Lvl2_Icon.enabled = false;
        Water_Damage_Icon.enabled = false;
        Fire_Damage_Icon.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckHealthUi();
        CheckManaUi();
        ChangeStats();
        CheckIconsUi();
    }


    void CheckHealthUi()
    {
        healthBar.fillAmount = (float)playerStats.currHealth / (float)playerStats.maxHealth;
    }
    void CheckManaUi()
    {
        manaBar.fillAmount = (float)playerStats.currMana / (float)playerStats.maxMana;
    }
    void CheckIconsUi()
    {
        if (playerStats.isOnFire == true)
        {
            Fire_Damage_Icon.enabled = true;
        }
        else if (playerStats.isOnFire == false)
        {
            Fire_Damage_Icon.enabled = false;
        }
        if (playerStats.IsWet == true)
        {
            Water_Damage_Icon.enabled = true;
        }
        else if (playerStats.IsWet == false)
        {
            Water_Damage_Icon.enabled = false;
        }
    }
    void ChangeStats()
    {
        if (isArmorlvl1On)
        {
            playerStats.armor.BaseValue = 5;
            
        }
        if (isArmorlvl2On)
        {
            playerStats.armor.BaseValue = 10;
        }
        if(isFirelvl1On)
        {
            
        }
    }



}
