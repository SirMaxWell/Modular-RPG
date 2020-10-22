
using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : BaseCharacterStats
{

    public CastSpell castSpell;
    Spell spell;
    bool isDamageOverTimeCoroutineRunning = false;
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

    void TakeDamage()
    {



       // int TotalAttack;
       // TotalAttack = baseDamage.getValue();
       // float TotalDamage;
       // TotalDamage = (Mathf.Sqrt(TotalAttack * TotalAttack) / (TotalAttack + baseDefence.getValue()));
       // //TotalDamage -= armor.getValue();
       // currHealth -= TotalDamage;
       // Debug.Log(TotalDamage);
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

   internal void StatusEffect(int finalElementDamage, int maxPotentialElementalDamage, int duration)
   {
        
        if(isDamageOverTimeCoroutineRunning == false)
        {
             StartCoroutine(DamageOverTime(finalElementDamage, maxPotentialElementalDamage, duration));
            isDamageOverTimeCoroutineRunning = true;

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
        //isDamageOverTimeCoroutineRunning = false;
    }
    
    
}
