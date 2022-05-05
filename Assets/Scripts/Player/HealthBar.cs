using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private PlayerHealth player;
    private int startHealth;
    void Start()
    {
        bar = transform.Find("Bar");
        var player1 = DataManager.player;
        player = player1.GetComponent<PlayerHealth>();
        startHealth = player.health;
    }

    // Update is called once per frame
    public void SetSize(float health)
    {
        bar.localScale = new Vector3(health / startHealth, 1f);
    }
}
