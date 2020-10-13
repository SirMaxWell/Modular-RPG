using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    [HideInInspector]
    public Spell spell;
    public PlayerStats playerStats;


    public void CalculateImpactDamage()
    {
        if(spell)
        {
            spell.minPotentialImpactDamage = spell.MaxPotentialImpactDamage / 2;
            spell.finalImpactDamage = Random.Range(spell.minPotentialImpactDamage, spell.MaxPotentialImpactDamage); // Randomise the final Damage
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
            PlayerStats enemy = collision.gameObject.GetComponent<PlayerStats>();

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
    }

    void BlastEffect(PlayerStats target)
    {
        target.TakeDamage(spell.finalImpactDamage);
        target.StatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);
        
        // Debug.Log("Burn Damage Hit for " + spell.finalElementDamage);
        Debug.Log(spell.name + " Spell hit " + target.name + " for " + spell.finalImpactDamage + " Damage!");
    }
    void StatusEffect(PlayerStats target)
    {
        target.StatusEffect(spell.finalElementDamage, spell.MaxPotentialElementalDamage, spell.Duration);
    }


}
