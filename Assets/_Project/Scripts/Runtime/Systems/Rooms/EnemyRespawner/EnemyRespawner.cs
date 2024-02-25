using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    public float respawnTimer;
    private void Start()
    {
        InitializeEnemies();
    }
    public List<GameObject> startingEnemies;
    public List<EnemyRespawnerEntry> enemiesList;
    
    public void RespawnEnemies()
    {
        if (enemiesList != null)
        {
            foreach (EnemyRespawnerEntry enemyEntry in enemiesList)
            {
                if (enemyEntry.current!=null)
                {
                    Destroy(enemyEntry.current);
                }
                enemyEntry.current = Instantiate(enemyEntry.enemy, enemyEntry.position, Quaternion.identity);
                enemyEntry.current.SetActive(true);
            }
        }
    }
    public void InitializeEnemies()
    {
        enemiesList = new List<EnemyRespawnerEntry>();
        if (startingEnemies != null)
        {
            for (int i = 0; i < startingEnemies.Count; i++)
            {
                EnemyRespawnerEntry respawnerEntry = new EnemyRespawnerEntry();
                respawnerEntry.enemy = Instantiate(startingEnemies[i]);
                respawnerEntry.enemy.SetActive(false);
                respawnerEntry.current = startingEnemies[i];
                respawnerEntry.position = startingEnemies[i].transform.position;
                enemiesList.Add(respawnerEntry);
            }
        }
    }
    public IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(respawnTimer);
        RespawnEnemies();
    }
    public void RoomEntered()
    {
        StopCoroutine("RespawnTimer");
    }
    public void RoomExited()
    {
        StartCoroutine("RespawnTimer");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RoomEntered();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RoomExited();
        }
    }
}
[System.Serializable]
public class EnemyRespawnerEntry
{
    public Vector2 position;
    public GameObject enemy;
    public GameObject current;
}
