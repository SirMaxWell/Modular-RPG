using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : BaseCharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currHealth = maxHealth;

        maxMana = 100;
        currMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        checkHP();
    }
}
