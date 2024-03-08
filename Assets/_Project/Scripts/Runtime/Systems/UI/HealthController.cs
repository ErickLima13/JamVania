using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Status status;

    private int currentHealth;

    private int maxHealth;

    public List<Image> healthRenderers = new();

    public List<Sprite> healthTextures = new();

    private void Start()
    {
        status.OnPlayerHit += TakeHit;
        ControlHealth();
    }

    public void ControlHealth()
    {
        maxHealth = status.maxLife;
        currentHealth = maxHealth;

        foreach (Image image in healthRenderers)
        {
            image.enabled = false;
        }

        for (int i = 0; i < currentHealth; i++)
        {
            healthRenderers[i].enabled = true;
        }
    }

    private void TakeHit()
    {
        healthRenderers[currentHealth - 1].sprite = healthTextures[0];
        currentHealth = status.maxLife;
    }

    public void GetHealth()
    {
        if (currentHealth < maxHealth)
        {
            status.maxLife++;
            currentHealth = status.maxLife;
            healthRenderers[currentHealth - 1].sprite = healthTextures[1];
        }
    }

    private void OnDestroy()
    {
        status.OnPlayerHit -= TakeHit;
    }

}
