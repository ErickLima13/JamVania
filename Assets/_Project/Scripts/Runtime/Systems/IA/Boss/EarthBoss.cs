using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBoss : MonoBehaviour
{

    public enum AttackState
    {
        Jump,
        Dash,
        Bomb
    }

    public AttackState currentState;

    private Transform player;
    private Vector3 initPos;


    [SerializeField] private List<GameObject> thornAttacks = new();


    [Header("Attack Times")]
    public float attackDelay;
    public float timeToJump;
    public float timeToDash;
    public float attackThornDuration;

    [Header("Attributes")]
    public float direction;
    public float wallDistance;
    public float speed;

    public Transform wallCheck;

    public LayerMask wallLayer;



    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        initPos = transform.position;

        DisableAll();
    }

    private void Update()
    {
        ControlState();
    }


    private void ControlState()
    {
        switch (currentState)
        {
            case AttackState.Jump:
                JumpAtack();
                break;
            case AttackState.Dash:
                DashAttack();
                break;
            case AttackState.Bomb:
                break;

        }
    }

    private void JumpAtack()
    {
        Flip();

        attackDelay += Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);

        if (attackDelay > timeToJump && transform.position == initPos)
        {
            float rand = Random.Range(0, 100);
            print(rand);
            if (rand < 35)
            {
                StartCoroutine(JumpAttack());
                attackDelay = 0;
            }
            else
            {
                ChangeState(AttackState.Dash);
            }
        }
    }

    private void DashAttack()
    {
        attackDelay += Time.deltaTime;

        if (attackDelay > timeToDash)
        {
            direction = player.localScale.x;

            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D wall = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, wallDistance, wallLayer);
            Debug.DrawRay(wallCheck.position, Vector2.right * direction * wallDistance, Color.red);

            if (wall.collider)
            {
                ChangeState(AttackState.Jump);
            }

        }
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

    private IEnumerator JumpAttack()
    {
        int idAttack = 0;

        yield return new WaitForSeconds(attackThornDuration);

        ActiveOne(thornAttacks[idAttack]);
        idAttack++;

        yield return new WaitForSeconds(attackThornDuration);

        ActiveOne(thornAttacks[idAttack]);
        idAttack++;

        yield return new WaitForSeconds(attackThornDuration);

        ActiveOne(thornAttacks[idAttack]);

        yield return new WaitForSeconds(attackThornDuration);

        DisableAll();

        ChangeState(AttackState.Dash);
    }


    private void ChangeState(AttackState newState)
    {
        attackDelay = 0;

        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    private void ActiveOne(GameObject activeObj)
    {
        foreach (GameObject g in thornAttacks)
        {
            g.SetActive(false);
        }

        activeObj.SetActive(true);  
    }

    private void DisableAll()
    {
        foreach (GameObject g in thornAttacks)
        {
            g.SetActive(false);
        }
    }
}
