﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterStats : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;
    public int currMana;
    public int maxMana;

    public bool isDead = false;
    public BaseStats baseDamage;
    public BaseStats baseDefence;
    public BaseStats armor;
    public BaseStats fireResistance;
    public void checkHP()
    {
        // if player is over healed
        if (currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
        // if player's hp is 0 then they are dead
        if (currHealth <= 0)
        {
            currHealth = 0;
            isDead = true;
        }
        if(currHealth > 0)
        {
            isDead = false;
        }
    }
}
