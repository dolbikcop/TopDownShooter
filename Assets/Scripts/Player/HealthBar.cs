using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private PlayerHealth player;
    private int startHealth;
    void Awake()
    {
        bar = transform.Find("Bar");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        startHealth = player.health;
    }

    // Update is called once per frame
    public void SetSize(float health)
    {
        bar.localScale = new Vector3(health / startHealth, 1f);
    }
}
