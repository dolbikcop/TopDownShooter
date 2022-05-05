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
    private bool isCollidesPlayer = false;
    void Start()
    {
        player = DataManager.player;
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        var ph = collision.gameObject.GetComponent<PlayerHealth>();
        isCollidesPlayer = true;
        StartCoroutine(DealDamage(ph));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        isCollidesPlayer = false;
    }

    private IEnumerator DealDamage(PlayerHealth ph)
    {
        while (true)
        {
            if (!isCollidesPlayer)
                yield break;
            ph.TakeDamage(damage);
            speed = 0;
            yield return new WaitForSeconds(.1f);
            speed = startSpeed;
            yield return new WaitForSeconds(1f);
        }
    }
}
