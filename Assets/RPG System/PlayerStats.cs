
using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : BaseCharacterStats
{

    public CastSpell castSpell;
    Spell spell;


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

    internal void TakeDamage(int finalImpactDamage)
    {
        //currHealth -= finalImpactDamage;
        //StartCoroutine(DamageOverTime(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration));

    }

   internal void StatusEffect(int finalElementDamage, int maxPotentialElementalDamage, int duration)
   {
        if(spell.elemental_Type == Spell.EleType.Fire)
        {
            StartCoroutine(DamageOverTime(finalElementDamage, maxPotentialElementalDamage, duration));

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
    }

    /*
    IEnumerator DamageOverTime(int finalElementDamage, int maxPotentialElementalDamage, Spell spell)
    {
        int amountDamaged = 0;
        int damageAmount = 10;
        int Duration = 5;
        int DamagePerLoop = damageAmount / Duration;
        while (amountDamaged < damageAmount)
        {


            Debug.Log("Dam Hit");
            amountDamaged += DamagePerLoop;
            yield return new WaitForSeconds(1f);
        }
    }
    */
}
