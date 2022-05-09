using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;
    private Score sc;

    private void Start()
    {
        sc = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var effect =Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("SP"))
        {
            sc.score++;
            Destroy(collision.gameObject);
        }
    }
}
