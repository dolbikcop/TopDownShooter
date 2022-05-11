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
    private Rigidbody2D rb;
    private bool isCollidesPlayer = false;
    void Start()
    {
        player = DataManager.player;
        startSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = player.GetComponent<Rigidbody2D>().position - rb.position;
        rb.MovePosition(rb.position + direction.normalized * Time.fixedDeltaTime * speed);
        Debug.DrawRay(transform.position, new Vector3(direction.x, direction.y, 1));
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
