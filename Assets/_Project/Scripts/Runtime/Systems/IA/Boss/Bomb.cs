using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;

    public float lifeTime;

    public bool noGravity;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        Vector2 scale;
        if (!noGravity)
        {
            scale = new Vector2(transform.localScale.x, 0.5f);
        }
        else
        {
            scale = new Vector2(transform.localScale.x, 0);
        }

        transform.Translate(speed * Time.deltaTime * scale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Status player))
        {
            if (player.statusTag == StatusTag.Player)
            {
                player.HealthChange(1);
                Destroy(gameObject);
            }
        }
    }
}
