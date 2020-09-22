
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
            TakeDamage(20);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            HealDamage(10);
        }
    }

    void TakeDamage( int damage)
    {
        int TotalAttack;
        TotalAttack = baseDamage.getValue();
        float TotalDamage;
        TotalDamage = (Mathf.Sqrt(TotalAttack * TotalAttack) / (TotalAttack + baseDefence.getValue()));
        damage -= armor.getValue();
        currHealth -= damage;
    }

    void HealDamage(int heal)
    {
        currHealth += heal;
    }
    void TakeFireDamage(int fireDamageAmount)
    {
    }
    



    


}
