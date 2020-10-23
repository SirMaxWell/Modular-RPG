
using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : BaseCharacterStats
{

    public CastSpell castSpell;
    Spell spell;
    bool isDamageOverTimeCoroutineRunning = false;
    bool isDryoverTimeCoroutineRunning = false;
    public bool isOnFire = false;
    public bool IsWet = false;

    void Start()
    {
       
        maxHealth = 100;
        currHealth = maxHealth;

        maxMana = 100;
        currMana = maxMana;

        
    }

    void Update()
    {
        checkHP();
        
        if(Input.GetKeyUp(KeyCode.F))
        {

            

        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            HealDamage(10);
        }
    }

    

    void HealDamage(int heal)
    {
        currHealth += heal;
    }

    internal void TakeBlastDamage(int finalImpactDamage)
    {
        Debug.Log("Hit");
        currHealth -= finalImpactDamage;
        
    }

   internal void BurnStatusEffect(int finalElementDamage, int maxPotentialElementalDamage, int duration)
   {
        
        if(isDamageOverTimeCoroutineRunning == false)
        {
             StartCoroutine(DamageOverTime(finalElementDamage, maxPotentialElementalDamage, duration));
             isDamageOverTimeCoroutineRunning = true;

        }
        
   }
   internal void WetStatusEffect()
    {
        if (isDryoverTimeCoroutineRunning == false)
        {
            StartCoroutine(DryOverTime());
            isDryoverTimeCoroutineRunning = true;
        }
    }

    IEnumerator DamageOverTime(int finalElementDamage, int maxPotentialElementalDamage, int duration)
    {
        int amountDamaged = 0;
        finalElementDamage = maxPotentialElementalDamage / duration;
        while (amountDamaged < maxPotentialElementalDamage)
        {
            currHealth -= finalElementDamage;
            Debug.Log(currHealth);
            Debug.Log("burn!");
            amountDamaged += finalElementDamage;
            yield return new WaitForSeconds(1f);
        }
        isDamageOverTimeCoroutineRunning = false;
        isOnFire = false;
        IsWet = false;
    }
    IEnumerator DryOverTime()
    {
        Debug.Log("start dry");
        yield return new WaitForSeconds(10f);
        isDryoverTimeCoroutineRunning = false;
        IsWet = false;
    }
    
}
