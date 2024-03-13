using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent<GameObject> OnHit;

    [SerializeField] private GameObject hitPrefab;

    public int maxLife;

    public int currentLife;

    private HealthEnemies healthEnemies;

    public bool canHit;

    private void Start()
    {
        canHit = true;
        currentLife = maxLife;

        healthEnemies = FindObjectOfType<HealthEnemies>();

    }

    public void HealthChange(int value, GameObject sender)
    {

        if (statusTag.Equals(StatusTag.Player) && canHit)
        {
            OnHit?.Invoke(sender);
            HitPlayer(value);
        }

        if(statusTag.Equals(StatusTag.Enemy))
        {
           HitEnemy(value, sender);
        }

        if (currentLife <= 0)
        {
            OnDie?.Invoke();
            //Destroy(gameObject, 1.4f);
        }
    }

    private void HitPlayer(int value)
    {
        canHit = false;
        currentLife -= value;
        StartCoroutine(DelayHit());
        OnPlayerHit?.Invoke();
    }

    private void HitEnemy(int value,GameObject sender)
    {
        currentLife -= value;
        float perc = currentLife / (float)maxLife;

        if (perc < 0)
        {
            perc = 0;
        }

        healthEnemies.ShowHealth(perc);
    }

    private IEnumerator DelayHit()
    {
        yield return new WaitForSeconds(2f);
        canHit = true;
    }
}