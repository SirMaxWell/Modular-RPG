﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;

    public Image armor_Icon;
    public bool isArmorlvl1On;
    public Image armor_Lvl2_Icon;
    public bool isArmorlvl2On;

    public Image Fire_Resis_Icon;
    public bool isFirelvl1On;
    public Image Fire_Resis_Lvl2_Icon;
    public bool isFirelvl2On;

    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        armor_Icon.enabled = false;
        armor_Lvl2_Icon.enabled = false;
        Fire_Resis_Icon.enabled = false;
        Fire_Resis_Lvl2_Icon.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealthUi();
        ChangeStats();
    }


    void CheckHealthUi()
    {
        healthBar.fillAmount = (float)playerStats.currHealth / (float)playerStats.maxHealth;
    }
    void ChangeStats()
    {
        if (isArmorlvl1On)
        {
            playerStats.armor.baseValue = 5;
            
        }
        if (isArmorlvl2On)
        {
            playerStats.armor.baseValue = 10;
        }
        if(isFirelvl1On)
        {
            
        }
    }



}
