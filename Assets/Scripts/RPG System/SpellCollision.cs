using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    [HideInInspector]
    public Spell spell;
    public PlayerStats playerStats;
    public EnemyStats enemyStats;


    public void CalculateImpactDamage()
    {
        if(spell)
        {
            spell.minPotentialImpactDamage = spell.MaxPotentialImpactDamage / 2;
            spell.finalImpactDamage = UnityEngine.Random.Range(spell.minPotentialImpactDamage, spell.MaxPotentialImpactDamage); // Randomise the final Damage
            //Debug.Log("FinalImapact damage = " + spell.finalImpactDamage + "for the spell" + spell.name);
        }
    }

    public void CalculateElementDamage()
    {
        if(spell)
        {
            spell.finalElementDamage = spell.MaxPotentialElementalDamage / spell.Duration;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>();

            if(enemy)
            {
                if(spell.spellType == Spell.SpellType.Blast)
                {
                    BlastEffect(enemy);
                }
                if(spell.spellType == Spell.SpellType.Status_Effect)
                {
                    StatusEffect(enemy);
                }
                
            }
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            if (player)
            {
                if (spell.spellType == Spell.SpellType.Blast)
                {
                    _BlastEffect(player);
                }
                if (spell.spellType == Spell.SpellType.Status_Effect)
                {
                    _JustStatusEffect(player);
                }
            }
        }
    }
    
    void BlastEffect(EnemyStats enemy)
    {
        if(spell.elemental_Type == Spell.EleType.Fire)
        {
            enemy.TakeBlastDamage(spell.finalImpactDamage);
            enemy.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);
            Debug.Log(spell.name + " Spell hit " + enemy.name + " for " + spell.finalImpactDamage + " Damage!");
            enemy.isOnFire = true;
            Debug.Log("On Fire");
        }
        if(spell.elemental_Type == Spell.EleType.Water)
        {
            enemy.TakeBlastDamage(spell.finalElementDamage);
            enemy.WetStatusEffect();
            enemy.IsWet = true;
            Debug.Log("IsWet");
        }
        
    }
    
    
    void StatusEffect(EnemyStats enemy)
    {
        if (spell.elemental_Type == Spell.EleType.Fire)
        {

            enemy.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);
            enemy.isOnFire = true;
        }
        if(spell.elemental_Type == Spell.EleType.Water)
        {
            enemy.WetStatusEffect();
            enemy.IsWet = true;
        }
    }

    void _BlastEffect(PlayerStats player)
    {
        if (spell.elemental_Type == Spell.EleType.Fire)
        {
            player.TakeBlastDamage(spell.finalImpactDamage);
            player.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);
            player.isOnFire = true;
            

        // Debug.Log("Burn Damage Hit for " + spell.finalElementDamage);
        //Debug.Log(spell.name + " Spell hit " + target.name + " for " + spell.finalImpactDamage + " Damage!");
        }
        if(spell.elemental_Type == Spell.EleType.Water)
        {
            player.TakeBlastDamage(spell.finalImpactDamage);
            player.WetStatusEffect();
            player.IsWet = true;
        }
    }
    void _JustStatusEffect(PlayerStats player)
    {
        if(spell.elemental_Type == Spell.EleType.Fire)
        {
            player.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);
            player.isOnFire = true;
        }
        if(spell.elemental_Type == Spell.EleType.Water)
        {
            player.WetStatusEffect();
            player.IsWet = true;
        }
    }


}
