using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private bool isPlayer;


    public void SetDamage(int value)
    {
        damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Status target))
        {
            switch (target.statusTag)
            {
                case StatusTag.Enemy:
                    if (isPlayer)
                    {
                        target.HealthChange(damage, gameObject);
                    }
                    break;
                case StatusTag.Player:
                    if (!isPlayer)
                    {
                        target.HealthChange(damage, gameObject);
                    }
                    break;
            }
        }
    }

}
