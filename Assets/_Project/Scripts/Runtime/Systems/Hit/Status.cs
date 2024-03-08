using System;
using UnityEngine;

public enum StatusTag
{
    Enemy,
    Player
}

public class Status : MonoBehaviour
{
    public StatusTag statusTag;   

    public event Action OnDie;

    public event Action OnPlayerHit;

    [SerializeField] private GameObject hitPrefab;

    public int maxLife;

    public void HealthChange(int value)
    {
        //GameObject temp = Instantiate(hitPrefab, transform.position, Quaternion.identity);
        //Destroy(temp, 0.5f);
        maxLife -= value;

        if (statusTag.Equals(StatusTag.Player))
        {
            OnPlayerHit?.Invoke();
        }

        if (maxLife <= 0)
        {
            OnDie?.Invoke();
            //Destroy(gameObject, 1.4f);
        }
    }
}