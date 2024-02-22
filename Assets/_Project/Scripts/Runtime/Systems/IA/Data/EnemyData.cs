using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
{
    public float speed;
    public float timerPatrol;
    public float distance;
    public float distanceAttack;
    public float attackTime;
    public int damage;
}
