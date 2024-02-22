using System.Collections;
using UnityEngine;

public class EnemyB : MonoBehaviour
{
    private Transform player;
    private Animator animator;

    private bool canAttack;

    private float speed;

    [SerializeField] private EnemyData enemyData;


    private void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>().transform;

        speed = enemyData.speed;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > enemyData.distanceAttack)
        {
            animator.SetBool("walk", true);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            if (!canAttack)
            {
                StartCoroutine(AttackDelay());
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

    private IEnumerator AttackDelay()
    {
        animator.SetBool("walk", false);
        animator.SetTrigger("attack");
        canAttack = true;

        yield return new WaitForSeconds(enemyData.attackTime);

        canAttack = false;
    }
}
