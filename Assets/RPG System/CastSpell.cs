using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public Transform SpawnLoc;
    public Camera Test;
   

    Spell spell;
    
    BaseCharacterStats characterStats;
    PlayerStats playerStats;


    public List<Spell> spellList = new List<Spell>();
    //private List<Spell> spellDataBase;

    void Start()
    {
        spell = (Spell)Resources.Load("Spells/" + gameObject.name, typeof(Spell));
        
        List<Spell> spellDataBase = GameObject.Find("RPGManager").GetComponent<RPGManager>().spellList;
        for (int i = 0; i < spellDataBase.Count; i++)
        {
            spellList.Add(spellDataBase[i]);
            

        }


    }
    


    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            CastMagic(spellList[0]);
            
            if(spell != null)
            {
                CastMagic(spell);

            }
        }

    }
    void CastMagic(Spell spell)
    {
        if(spell.spellPrefab == null)
        {
            Debug.LogWarning("Spell prefab is null");
        }
        else
        {
            GameObject spellObject = Instantiate(spell.spellPrefab, SpawnLoc.position, Test.GetComponent<Transform>().rotation); //Camera.main.GetComponent<Transform>().rotation);
            spellObject.AddComponent<Rigidbody>();
            spellObject.GetComponent<Rigidbody>().useGravity = false;
            spellObject.GetComponent<Rigidbody>().velocity = spellObject.transform.forward * spell.ProjectileSpeed;
            spellObject.name = spell.spellName;
            spellObject.transform.parent = GameObject.Find("RPGManager").transform;
            SpellCollision spellCollision = spellObject.GetComponent<SpellCollision>();
            if(spellCollision)
            {
                spellCollision.spell = spell;
                spellCollision.CalculateImpactDamage();
                
                spellCollision.CalculateElementDamage();
                


            }
            Destroy(spellObject, 2);
        }
        

    }

    

    
    /*
    IEnumerator DamageOverTimeFlat()
    {
        float counter = 0;
        
        for (int i = 0; i < spellDataBase.Count; i++)
        {
            while (counter < spellList[i].Duration)
            {
                foreach (var item in spellList)
                {
                    if(spellList[i].damage_Type == Spell.DamType.OverTimeFlat)
                    {
                        Debug.Log("Burn");
                        spellList[i].finalElementDamage = spellList[i].MaxPotentialElementalDamage / spellList[i].Duration;
                        yield return new WaitForSeconds(spellList[i].Duration);
                    }
                }

            }
        }
        
    }
    
     */
    
}
