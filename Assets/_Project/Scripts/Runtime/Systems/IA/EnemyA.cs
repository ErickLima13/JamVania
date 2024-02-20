using System.Collections;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Idle
    }

    public State currentState;

    public float speed;
    public float timerPatrol;

    public float distance;
    public float distanceAttack;

    public float direction;

    public bool isWalk;
    public bool isRight;
    public bool isAttack;

    public LayerMask playerLayer;

    public Transform target;
    public Transform groundCheck;

    public Transform viewPos;

    private Animator animator;

    public float walkTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(viewPos.position, Vector2.right * direction, distanceAttack,playerLayer);
        Debug.DrawRay(viewPos.position, Vector2.right * direction * distanceAttack, Color.yellow);

        if (hit.collider)
        {
            print(hit.collider.name);
            target = hit.collider.transform;

        }
        else
        {
            target = null;
        }
       

        ControlIA();
    }

    private void ControlIA()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Idle:
                Idle();
                break;
        }
    }

    private void Patrol()
    {
        animator.SetBool("walk", true);

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        Debug.DrawRay(groundCheck.position, Vector2.down * distance, Color.red);

        if (!ground.collider)
        {
            if (isRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
                direction = 1f;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
                direction = -1f;   
            }      
        }

        walkTime += Time.deltaTime;

        if (walkTime > timerPatrol)
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

    private IEnumerator PatrolSystem()
    {
        ChangeState(State.Idle);
        animator.SetBool("walk", false);

        yield return new WaitForSeconds(timerPatrol);

        ChangeState(State.Patrol);
    }

    private void ChangeState(State newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

}
