using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHealth : MonoBehaviour
{
    private HealthController healthController;
    private Status healthStatus;

    [SerializeField] private bool isAttribute;

    private void Start()
    {
        healthController = FindObjectOfType<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if (isAttribute)
            {
                healthStatus = player.GetComponent<Status>();
                if (healthStatus.currentLife < 10)
                {
                    healthStatus.currentLife++;
                    healthController.ControlHealth();
                }
            }
            else
            {
                healthController.GetHealth();
            }

            Destroy(gameObject, 0.2f);
        }
    }
}
