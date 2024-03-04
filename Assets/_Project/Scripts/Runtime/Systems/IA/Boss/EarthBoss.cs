using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EarthBoss : MonoBehaviour
{

    #region old

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

    public int numBombs;

    public GameObject bombPrefab;

    public bool canJump;
    public bool canShoot;
    public bool isLeft;

    #endregion

    public EarthStateMachine StateMachine
    {
        get; private set;
    }

    public JumpAttackState JumpAttackState
    {
        get; private set;
    }

    [SerializeField] private BossData bossData;


    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        initPos = transform.position;
        DisableAll();

        JumpAttackState = new(this, StateMachine, bossData, "jump");
     
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }


    public void JumpAtack()
    {
        Flip();

        attackDelay += Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);

        if (attackDelay > timeToJump && transform.position == initPos && !canJump)
        {
            canJump = true;
            attackDelay = 0;
            StartCoroutine(JumpAttack());
        }
    }

    public void DashAttack()
    {
        attackDelay += Time.deltaTime;


        direction = isLeft ? -1 : 1;

        if (attackDelay > timeToDash)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D wall = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, wallDistance, wallLayer);
            Debug.DrawRay(wallCheck.position, Vector2.right * direction * wallDistance, Color.red);

            if (wall.collider)
            {
                ChooseAttack();
            }
        }
    }


    private void BombAttack()
    {
        Flip();

        if (numBombs < 3 && !canShoot)
        {
            canShoot = true;
            StartCoroutine(ShootBomb());
        }
        else if(numBombs >= 3)
        {
            ChooseAttack();
        }
    }

    private IEnumerator ShootBomb()
    {
        GameObject temp = Instantiate(bombPrefab, wallCheck.transform.position,wallCheck.transform.rotation);
        numBombs++;

        yield return new WaitForSeconds(attackThornDuration);

        canShoot = false;
    }


    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new(0, 180, 0);
            isLeft = true;    
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
            isLeft = false;
        }
    }

    public IEnumerator JumpAttack()
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
    }


    private void ChangeState(AttackState newState)
    {
        attackDelay = 0;
        numBombs = 0;

        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    private void ChooseAttack()
    {
        float rand = Random.Range(0, 100);
        print(rand);

        if (rand >= 80)
        {
            Debug.LogWarning("JUMP");
            canJump = false;
            ChangeState(AttackState.Jump);
        }
        else if (rand >= 55)
        {
            Debug.LogWarning("DASH");

            Flip();
            ChangeState(AttackState.Dash);
        }
        else
        {
            Debug.LogWarning("BOMB");
            ChangeState(AttackState.Bomb);
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
