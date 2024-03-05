using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        Vector2 scale = new Vector2(transform.localScale.x, 0.5f);
        transform.Translate(speed * Time.deltaTime * scale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Status player))
        {
            if (player.statusTag == StatusTag.Player)
            {
                player.HealthChange(1);
                Destroy(gameObject);
            }
        }
    }
}
