using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 120;

    public GameObject deathScreen;

    public HealthBar healthBar;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetSize(health);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Instantiate(deathScreen, transform.position, Quaternion.identity);
        gameObject.GetComponent<PlayerMovement>().speed = 0f;
    }
}
