using System.Collections;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Idle,
        Attack
    }

    private bool isLeft;
    private bool isAttack;

    private Animator animator;

    private HitBox hitBox;

    private float direction = 1;
    private float walkTime;
    private float speed;

    [SerializeField] private State currentState;

    [SerializeField] private EnemyData enemyData;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform viewPos;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask wallLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        hitBox = GetComponentInChildren<HitBox>();
    }

    private void Update()
    {
        ControlIA();
    }

    private void ControlIA()
    {
        FindPlayer();

        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Idle:
                Idle();
                break;
            case State.Attack:
                Attack();
                break;
        }
    }

    private void Patrol()
    {
        speed = enemyData.speed;

        animator.SetBool("walk", true);

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D wall = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, enemyData.distance,wallLayer);
        Debug.DrawRay(wallCheck.position, Vector2.right * direction * enemyData.distance, Color.red);

        if (wall.collider)
        {
            if (isLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isLeft = false;
                direction = -1f;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isLeft = true;
                direction = 1f;
            }
        }

        walkTime += Time.deltaTime;

        if (walkTime > enemyData.timerPatrol)
        {
            float rand = Random.Range(0, 50);
            if (rand < 25)
            {
                ChangeState(State.Idle);
                walkTime = 0;
            }
        }
    }

    private void Idle()
    {
        StartCoroutine(PatrolSystem());
    }

    private void Attack()
    {
        hitBox.SetDamage(enemyData.damage);

        if (!isAttack)
        {
            StartCoroutine(AttackDelay());
        }
    }

    private void FindPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(viewPos.position, Vector2.right * direction, enemyData.distanceAttack, playerLayer);
        Debug.DrawRay(viewPos.position, Vector2.right * direction * enemyData.distanceAttack, Color.yellow);

        if (hit.collider)
        {
            speed = 0;
            ChangeState(State.Attack);
        }
        else
        {
            ChangeState(State.Patrol);
        }
    }

    private IEnumerator PatrolSystem()
    {
        ChangeState(State.Idle);
        animator.SetBool("walk", false);

        yield return new WaitForSeconds(enemyData.timerPatrol);

        ChangeState(State.Patrol);
    }

    private IEnumerator AttackDelay()
    {
        isAttack = true;
        animator.SetBool("walk", false);
        animator.SetTrigger("attack");

        yield return new WaitForSeconds(enemyData.attackTime);

        isAttack = false;
    }

    private void ChangeState(State newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

}
