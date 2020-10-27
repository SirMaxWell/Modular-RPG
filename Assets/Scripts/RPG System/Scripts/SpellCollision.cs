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

    // calculates the min impact damage and randomises the final damage output between the min and max 
    public void CalculateImpactDamage()
    {
        if(spell)
        {
            spell.minPotentialImpactDamage = spell.MaxPotentialImpactDamage / 2; // hardcodes the minimum damage to be half of the Max damage
            spell.finalImpactDamage = UnityEngine.Random.Range(spell.minPotentialImpactDamage, spell.MaxPotentialImpactDamage); // Randomise the final Damage
            
        }
    }
    // calculates the final elemental damage by dividing the max elemental damage by its duration
    public void CalculateElementDamage()
    {
        if(spell)
        {
            spell.finalElementDamage = spell.MaxPotentialElementalDamage / spell.Duration;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        // spell collision 
        
        if(collision.gameObject.CompareTag("Enemy")) // if the object is tags as an enemy
        {
            EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>(); // gets the enemy'stats

            if(enemy)
            {
                if(spell.spellType == Spell.SpellType.Blast)    // if spell is blast type
                {
                    BlastEffect(enemy); // do spell effect
                }
                if(spell.spellType == Spell.SpellType.Status_Effect) // if spell is just status Effect
                {
                    StatusEffect(enemy); // do spell effect
                }
                
            }
        }
        
        if (collision.gameObject.CompareTag("Player"))  // if the object is tags as an player 
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            if (player)
            {
                if (spell.spellType == Spell.SpellType.Blast) // if spell is blast type
                {
                    _BlastEffect(player);   // do spell effect
                }
                if (spell.spellType == Spell.SpellType.Status_Effect) // if spell is just status Effect
                {
                    _JustStatusEffect(player); //do spell effect
                }
            }
        }
    }
    
    void BlastEffect(EnemyStats enemy) // Blast Type spells for enemies only
    {
        if(spell.elemental_Type == Spell.EleType.Fire)      // if the elemental type is set to fire                                                        
        {
            enemy.TakeBlastDamage(spell.finalImpactDamage);                                                         // Calls the Blast Damage Function on the enemy
            enemy.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);    // Calls the Burn Function on the enemy
            Debug.Log(spell.name + " Spell hit " + enemy.name + " for " + spell.finalImpactDamage + " Damage!");    // Debug
            Debug.Log(enemy.name + " will be on fire for " + spell.Duration + " Secs");                             // Debug
            enemy.isOnFire = true;                                                                                  // sets the bool for IsOnFire to true
            Debug.Log("On Fire");
        }                                                                                                           
        if(spell.elemental_Type == Spell.EleType.Water) // if the elemental type is set to water
        {                                                                                                           // Calls the Blast Damage Function on the enemy
            enemy.TakeBlastDamage(spell.finalElementDamage);                                                        // Calls the wet function on the enemy
            Debug.Log(spell.name + " Spell hit " + enemy.name + " for " + spell.finalElementDamage + "Damage!");    // Debug
            Debug.Log(enemy.name + " will be wet for " + spell.Duration + " Secs");                                 // Debug
            enemy.WetStatusEffect(spell.Duration);                                                                  // sets the bool, for IsWet to true
            enemy.IsWet = true;
            Debug.Log("IsWet");
        }
        
    }
    
    
    void StatusEffect(EnemyStats enemy) // Just Status Effects for enemies only
    {
        if (spell.elemental_Type == Spell.EleType.Fire)                                                                   
        {                                                                                                                                                                                                                   // sets the bool for IsOnFire to true
            enemy.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);    // Calls the Burn Function on the player
            Debug.Log(spell.name + " Spell hit " + enemy.name + " for " + spell.finalImpactDamage + " Damage!");    // Debug
            enemy.isOnFire = true;                                                                                  // sets the bool for IsOnFire to true
        }
        if(spell.elemental_Type == Spell.EleType.Water)   
        {                                                
            enemy.WetStatusEffect(spell.Duration);                                                      // Calls the Wet Function on the player  
            Debug.Log(enemy.name + " will be wet for " + spell.Duration + " Secs");                   // Debug
            enemy.IsWet = true;                                                                         // sets the bool, for IsWet to true
        }
    } 

    void _BlastEffect(PlayerStats player)           // Blast Type spells for players only 
    {
        if (spell.elemental_Type == Spell.EleType.Fire)                                                             // if the elemental type is set to fire
        {
            player.TakeBlastDamage(spell.finalImpactDamage);                                                        // Calls the Blast Damage Function on the player
            player.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);   // Calls the Burn Function on the player
            Debug.Log(spell.name + " Spell hit " + player.name + " for " + spell.finalElementDamage + " Damage!");  // Debug
            Debug.Log(player.name + " will be on fire for " + spell.Duration + " Secs");                            // Debug
            player.isOnFire = true;                                                                                 // sets the bool for IsOnFire to true
        }
        if(spell.elemental_Type == Spell.EleType.Water)                                                             // if the elemental type is set to water
        {
            player.TakeBlastDamage(spell.finalImpactDamage);                                                        // Calls the Blast Damage Function on the player
            player.WetStatusEffect(spell.Duration);                                                                 // Calls the wet function on the player
            Debug.Log(spell.name + " Spell hit " + player.name + " for " + spell.finalImpactDamage + " Damage!");   // Debug
            Debug.Log(player.name + " will be wet for " + spell.Duration + " Secs");                                // Debug
            player.IsWet = true;                                                                                    // sets the bool, for IsWet to true
        }
    }
    void _JustStatusEffect(PlayerStats player)      // Just Status Effects for players only 
    {
        if(spell.elemental_Type == Spell.EleType.Fire)
        {
            player.BurnStatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);    // Calls the Burn Function on the player
            Debug.Log(player.name + " will be on fire for " + spell.Duration + " Secs");                            // Debug
            player.isOnFire = true;                                                                                 // sets the bool for IsOnFire to true
        }
        if(spell.elemental_Type == Spell.EleType.Water)
        {
            player.WetStatusEffect(spell.Duration);                                                                  // Calls the Wet Function on the player
            Debug.Log(player.name + " will be wet for " + spell.Duration + " Secs");                                // Debug
            player.IsWet = true;                                                                                    // sets the bool, for IsWet to true
        }
    }


}
