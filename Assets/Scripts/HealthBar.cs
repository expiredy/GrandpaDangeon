using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100f;
    public static HealthBar instance;

    private Image healthBar;
    private void Awake()
    {
        healthBar = GetComponent<Image>();
        currentHealth = maxHealth;
        instance = this;
    }

    public void SetHP(float hp)
    {
        currentHealth = hp;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
