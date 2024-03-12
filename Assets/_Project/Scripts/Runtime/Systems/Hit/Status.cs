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

    public int currentLife;

    private HealthEnemies healthEnemies;

    private void Start()
    {
        currentLife = maxLife;

        healthEnemies = FindObjectOfType<HealthEnemies>();

    }

    public void HealthChange(int value)
    {
        //GameObject temp = Instantiate(hitPrefab, transform.position, Quaternion.identity);
        //Destroy(temp, 0.5f);
        currentLife -= value;

        float perc = currentLife / (float)maxLife;

        if (perc < 0)
        {
            perc = 0;
        }

        Debug.LogWarning(perc);

        if (statusTag.Equals(StatusTag.Player))
        {
            OnPlayerHit?.Invoke();
        }

        if(statusTag.Equals(StatusTag.Enemy))
        {
            healthEnemies.ShowHealth(perc);
        }

        if (currentLife <= 0)
        {
            OnDie?.Invoke();
            //Destroy(gameObject, 1.4f);
        }
    }

}