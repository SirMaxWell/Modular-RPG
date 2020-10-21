﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public float Delay = 5f;
    public float nextFire = 0f;
    public Transform SpawnLoc;

    Spell spell;
    public List<Spell> spellList = new List<Spell>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(Time.time > nextFire)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                nextFire = Time.time + Delay;
                ShootMagic(spellList[0]);
                if(spell !=null)
                {
                    ShootMagic(spell);
                }
            }
        }
    }

    public void ShootMagic(Spell spell)
    {
        if (spell.spellPrefab == null)
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
            if (spellCollision)
            {
                spellCollision.spell = spell;
                if (spell.elemental_Type == Spell.EleType.Water)
                {
                    spellCollision.CalculateImpactDamage();
                }
                if (spell.elemental_Type == Spell.EleType.Fire)
                {
                    spellCollision.CalculateImpactDamage();
                    spellCollision.CalculateElementDamage();
                }





            }
            Destroy(spellObject, 2);
        }


    }


}
