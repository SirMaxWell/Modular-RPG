
using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : BaseCharacterStats
{

    public CastSpell castSpell;
    Spell spell;
    bool isDamageOverTimeCoroutineRunning = false; //sets all of them to false to begin with
    bool isDryoverTimeCoroutineRunning = false;
    public bool isOnFire = false;
    public bool IsWet = false;

    void Start()
    {
       
        maxHealth = 100; // sets max hp
        currHealth = maxHealth;

        maxMana = 100; // sets max mana
        currMana = maxMana;

        
    }

    void Update()
    {
        checkHP(); // checks to see if the player is dead 
        CheckStatusEffect(); // checks the status of the player 
    }

    void CheckStatusEffect()
    {
        if(isOnFire == true && IsWet == true) // if the player is both on fire and wet 
        {
            StopAllCoroutines(); // stops all coroutines 
            isDamageOverTimeCoroutineRunning = false; // sets to false
            isDryoverTimeCoroutineRunning = false; // sets to false
            IsWet = false; // sets to false
            isOnFire = false; // sets to false
            Debug.Log("Stop"); // debug
            Debug.Log("Player is no longer wet or on fire"); // debug
        }
    }
    
    /* not using right now 
    void HealDamage(int heal)
    {
        currHealth += heal;
    }
    */

    internal void TakeBlastDamage(int finalImpactDamage)
    {
        Debug.Log("Hit"); // debug
        currHealth -= finalImpactDamage; // takes final damage from player's hp
        
    }

   internal void BurnStatusEffect(int finalElementDamage, int maxPotentialElementalDamage, int duration)
   {
        
        if(isDamageOverTimeCoroutineRunning == false) // cant have multipe burn coroutines running 
        {
             StartCoroutine(DamageOverTime(finalElementDamage, maxPotentialElementalDamage, duration)); // starts the burn effect/ damage over time 
             isDamageOverTimeCoroutineRunning = true; // sets to true 

        }
        
   }
   internal void WetStatusEffect(int duration)
    {
        if (isDryoverTimeCoroutineRunning == false) // cant have multipe drying coroutines running
        {
            StartCoroutine(DryOverTime(duration)); // starts the dry over time coroutine 
            isDryoverTimeCoroutineRunning = true; // sets to false
        }
    }

    IEnumerator DamageOverTime(int finalElementDamage, int maxPotentialElementalDamage, int duration)
    {
        int amountDamaged = 0;
        finalElementDamage = maxPotentialElementalDamage / duration;
        // loops until reaching amount damaged
        while (amountDamaged < maxPotentialElementalDamage)
        {
            currHealth -= finalElementDamage;
            Debug.Log(currHealth);
            Debug.Log("burn!");
            amountDamaged += finalElementDamage;
            yield return new WaitForSeconds(1f); // waits for 1 sec
        }
        isDamageOverTimeCoroutineRunning = false; // sets back false
        isOnFire = false; // sets back false

    }
    IEnumerator DryOverTime(int duration)
    {
        
        Debug.Log("Wet");
        yield return new WaitForSeconds(duration); // waits for duration until sets everything back to false
        Debug.Log("Dry");
        isDryoverTimeCoroutineRunning = false;
        IsWet = false;
    }
    
}
