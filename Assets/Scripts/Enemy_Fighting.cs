using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fighting : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    private float startSpeed;

    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        RotateTowardsTarget();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
        if (ph)
        {
            ph.TakeDamage(damage);
            speed = 0;
        }

        speed = startSpeed;
    }
    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = transform.position - player.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
