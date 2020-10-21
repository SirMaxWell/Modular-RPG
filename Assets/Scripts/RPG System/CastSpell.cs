using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    public Transform SpawnLoc;
    public float cooldownTime;
    private float nextFireTime = 0;
    Spell spell;
    
    


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
       if(Time.time > nextFireTime)
        {
          if(Input.GetMouseButton(0))
          {
            nextFireTime = Time.time + cooldownTime;
            CastMagic(spellList[0]);
            
            if(spell != null)
            {
                CastMagic(spell);

            }
          }
        }

    }
    public void CastMagic(Spell spell)
    {
        if(spell.spellPrefab == null)
        {
            Debug.LogWarning("Spell prefab is null");
        }
        else
        {
            GameObject spellObject = Instantiate(spell.spellPrefab, SpawnLoc.position, SpawnLoc.rotation); //Camera.main.GetComponent<Transform>().rotation);
            spellObject.AddComponent<Rigidbody>();
            spellObject.GetComponent<Rigidbody>().useGravity = false;
            spellObject.GetComponent<Rigidbody>().velocity = spellObject.transform.forward * spell.ProjectileSpeed;
            spellObject.name = spell.spellName;
            spellObject.transform.parent = GameObject.Find("RPGManager").transform;
            SpellCollision spellCollision = spellObject.GetComponent<SpellCollision>();
            if(spellCollision)
            {
                spellCollision.spell = spell;
                if(spell.elemental_Type == Spell.EleType.Water)
                {
                    spellCollision.CalculateImpactDamage();
                }
                if(spell.elemental_Type == Spell.EleType.Fire)
                {
                    spellCollision.CalculateImpactDamage();
                    spellCollision.CalculateElementDamage();
                }
                
                
                


            }
            Destroy(spellObject, 2);
        }
        

    }

    

    
   
    
}
