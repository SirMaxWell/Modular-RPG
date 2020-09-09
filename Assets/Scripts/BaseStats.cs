using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public int currHealth;
    public int maxHealth;
    public int currMana;
    public int maxMana;

    public bool isDead = false;

   public void checkHP()
    {
        // if player is over healed
        if(currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
        // if player's hp is 0 then they are dead
        if(currHealth <= 0)
        {
            currHealth = 0;
            isDead = true;
        }
    }

}
