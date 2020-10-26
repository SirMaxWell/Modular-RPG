using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterStats : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;

    //public float HealthCap;
    //public float limiter_1 = 50;
    //public float Exp;
    //public float limiter_2 = 0.8f;
    //public int currLevel = 1;
    public float currMana;
    public float maxMana;

    public bool isDead = false;
    public BaseStats baseDamage;
    public BaseStats baseDefence;
    public BaseStats armor;
    public BaseStats fireResistance;
    [HideInInspector]
    public Spell spellScript;


    

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

    
    void CalcHp()
    {
       // maxHealth = maxHealth / (1 + limiter_1 * Exp) * (limiter_2 * currLevel);
    }
    

    
}
