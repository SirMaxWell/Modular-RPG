using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Spell spell;
    void CalucateThing()
    {
        spell.minPotentialImpactDamage = spell.MaxPotentialImpactDamage / 2;
        //spellScript.minPotentialElementalDamage = spellScript.MaxPotentialElementalDamage / 2;

        //spell.finalImpactDamage = UnityEngine.Random.Range(spell.minPotentialImpactDamage, spell.MaxPotentialImpactDamage);
        //finalElementDamage = Random.Range(spellScript.minPotentialElementalDamage, spellScript.MaxPotentialElementalDamage);
    }
}
