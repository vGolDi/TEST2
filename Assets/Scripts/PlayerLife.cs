using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int playerHP = 100;
    public HealthBar healthBar;
    float currentHealth;

    private void Start()
    {
        currentHealth = playerHP;
    }

    public void PlayerTakeDamage(float damage)
    {

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int heal)
    {
        currentHealth += heal;

        if (currentHealth <= playerHP)
        {
            healthBar.SetHealth(currentHealth);
        }
    }
}