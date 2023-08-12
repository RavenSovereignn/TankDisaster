
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TankClass : MonoBehaviour
{
    [Header("Variables")]
    public float health;
    public Image HealthBarFill;
    public float cooldownTime = 10f;
    private float nextHealTime = 0;
    public TextMeshProUGUI HealthCountUI;

    void Start()
    {
        health = 100f;
    }


    void Update()
    {
        #region HealthSystem
        HealthBarFill.fillAmount = health / 100;
        HealthCountUI.text = health.ToString("F0");
        //Passive health regen
        if (health < 100)
        {
            if (Time.time > nextHealTime)
            {
                HealDmg(10);
                nextHealTime = Time.time + cooldownTime;
            }
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    public void TakeDmg(int amount)
    {
        health -= amount;
    }
    public void HealDmg(int amount)
    {
        health += amount;
    }
}

