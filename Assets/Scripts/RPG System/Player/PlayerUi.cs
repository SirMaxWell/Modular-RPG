using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Image healthBar; // hp bar that appears on the players screen 
    public Image manaBar; // mp bar that appears on the players screen 
    /* not using right now
    public Image armor_Icon;
    public Image armor_Lvl2_Icon;
    public bool isArmorlvl1On;
    public bool isArmorlvl2On;

    public Image Fire_Resis_Icon;
    public Image Fire_Resis_Lvl2_Icon;
    public bool isFirelvl1On;
    public bool isFirelvl2On;
    */
    public Image Water_Damage_Icon; // water icon that appears on the players screen 
    public Image Fire_Damage_Icon; // Fire icon that appears on the players screen 

    PlayerStats playerStats;
    
    void Start()
    {
        playerStats = GetComponent<PlayerStats>(); // gets player stats 
        Water_Damage_Icon.enabled = false; // sets them to false to begin
        Fire_Damage_Icon.enabled = false;   // sets them to false to begin
        //armor_Icon.enabled = false;
        //armor_Lvl2_Icon.enabled = false;
        //Fire_Resis_Icon.enabled = false;
        //Fire_Resis_Lvl2_Icon.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        CheckHealthUi(); // constantly updates health
        CheckManaUi(); // constantly updates Mana
       // ChangeStats();
        CheckIconsUi(); // constantly updates Icons
    }


    void CheckHealthUi()
    {
        healthBar.fillAmount = (float)playerStats.currHealth / (float)playerStats.maxHealth; // changes the fill amount for the hp bar
    }
    void CheckManaUi()
    {
        manaBar.fillAmount = (float)playerStats.currMana / (float)playerStats.maxMana; // changes the fill amount for the mp bar
    }
    void CheckIconsUi()
    {
        // changes the icons on and off
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
    /* not using right now
    void ChangeStats()
    {
        if (isArmorlvl1On)
        {
            //playerStats.armor.BaseValue = 5;
            
        }
        if (isArmorlvl2On)
        {
            playerStats.armor.BaseValue = 10;
        }
        if(isFirelvl1On)
        {
            
        }
    }
    */



}
