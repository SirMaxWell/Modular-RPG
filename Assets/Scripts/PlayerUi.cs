using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;

    BaseStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<BaseStats>();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerStats.currHealth;
        manaBar.fillAmount = playerStats.currMana;
    }
}
