
using UnityEngine;

public class PlayerStats : BaseCharacterStats
{
    // Start is called before the first frame update

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
            TakeDamage(10);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            HealDamage(10);
        }
    }

    void TakeDamage( int damageAmount)
    {
        damageAmount -= armor.getValue();
        currHealth -= damageAmount;
    }

    void HealDamage(int heal)
    {
        currHealth += heal;
    }



    


}
