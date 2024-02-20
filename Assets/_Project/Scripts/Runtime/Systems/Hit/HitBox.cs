using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private int damage;

    public void SetDamage(int d)
    {
        damage = d;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Status enemy))
        {
            enemy.HealthChange(damage);
        }
    }

}
