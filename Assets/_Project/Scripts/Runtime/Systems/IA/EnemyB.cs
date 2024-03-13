using UnityEngine;

public class EnemyB : MonoBehaviour
{
    private Transform player;

    private Status statusPlayer;

    private Status mStatus;

    private float speed;

    [SerializeField] private EnemyData enemyData;

    public float waitTime;

    public float positionY;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        statusPlayer = player.GetComponent<Status>();

        mStatus = GetComponent<Status>();

        mStatus.OnDie += Death;
        speed = enemyData.speed;


    }

    private void Update()
    {
        Vector3 newPos = new(player.position.x, positionY, player.position.z);
        if (Vector2.Distance(transform.position, newPos) > enemyData.distanceAttack)
        {
            waitTime = 0;
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        }
        else
        {
            waitTime += Time.deltaTime;
            if (waitTime >= enemyData.attackTime)
            {
                statusPlayer.HealthChange(1, gameObject);
                waitTime = 0;
            }
        }

        Flip();
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void Death()
    {
        Destroy(gameObject, 0.1f);
    }

    private void OnDestroy()
    {
        mStatus.OnDie -= Death;
    }
}
