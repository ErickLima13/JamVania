using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceThorn : MonoBehaviour
{
    private Rigidbody2D body2d;


    private void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.gravityScale = Random.Range(0.1f, 0.3f);

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Status player))
        {
            if (player.statusTag == StatusTag.Player)
            {
                player.HealthChange(1);
                Destroy(gameObject);
            }


        }
    }
}
