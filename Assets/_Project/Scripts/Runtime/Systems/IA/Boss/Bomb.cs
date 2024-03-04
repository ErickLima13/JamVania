using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);
    }
}
