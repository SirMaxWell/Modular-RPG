using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public Transform SpawnLoc; // spawn loc for the player
    public float cooldownTime; // cool down time
    private float nextFireTime = 0; 
    Spell spell;
    public List<Spell> spellList = new List<Spell>();
    //private List<Spell> spellDataBase;

    void Start()
    {
        spell = (Spell)Resources.Load("Spells/" + gameObject.name, typeof(Spell));

        /*
        List<Spell> spellDataBase = GameObject.Find("RPGManager").GetComponent<RPGManager>().spellList;
        for (int i = 0; i < spellDataBase.Count; i++)
        {
            spellList.Add(spellDataBase[i]);
            

        }
        */

    }
    


    void FixedUpdate()
    {
       if(Time.time > nextFireTime) // can only shoot if cooldown is done 
        {
          if(Input.GetMouseButton(0)) // if pressing left mouse click
          {
            nextFireTime = Time.time + cooldownTime; // cool down 
            CastMagic(spellList[0]); // cast spell that is first in list
            if(spell != null)
            {
                CastMagic(spell);

            }
          }
        }

    }
    public void CastMagic(Spell spell)
    {
        if(spell.spellPrefab == null) // if spell prefab is null
        {
            Debug.LogWarning("Spell prefab is null"); // warning 
        }
        else
        {
            GameObject spellObject = Instantiate(spell.spellPrefab, SpawnLoc.position, SpawnLoc.rotation); // spawns the object from the spawn loc on the player
            spellObject.AddComponent<Rigidbody>();  // adds a rigidbody to the spell object
            spellObject.GetComponent<Rigidbody>().useGravity = false;   // sets the gravity to false so the object just doesnt fall to the ground
            spellObject.GetComponent<Rigidbody>().velocity = spellObject.transform.forward * spell.ProjectileSpeed; // adds velocity based projectile speed value 
            spellObject.name = spell.spellName;
            Debug.Log("Player used " + spell.ManaCost);             // debug
            PlayerStats playerStats = GetComponent<PlayerStats>(); // gets the player stats
            playerStats.currMana -= spell.ManaCost;
            Debug.Log(playerStats.currMana);                       // debug
            
            spellObject.transform.parent = GameObject.Find("RPGManager").transform;
            SpellCollision spellCollision = spellObject.GetComponent<SpellCollision>();
            if (spellCollision) // spell collides 
            {
                spellCollision.spell = spell;
                if(spell.elemental_Type == Spell.EleType.Water) // if spell type is water 
                {
                    spellCollision.CalculateImpactDamage(); // calculate impact damage
                }
                if(spell.elemental_Type == Spell.EleType.Fire) // if spell type is fire 
                {
                    spellCollision.CalculateImpactDamage(); // calculate impact damage 
                    spellCollision.CalculateElementDamage(); // calculate element damage
                }
                
                
                


            }
            
            
            Destroy(spellObject, 2); // destroies the object after 2 secs
        }
        

    }

    

    
   
    
}
