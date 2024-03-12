using System.Collections;
using UnityEngine;

public class HitTheGround : FireState
{

    private Transform player;

    public Animator effectAnimator;

    public GameObject alertObject;

    public float timerToAlert;



    private void Start()
    {
        player = FindObjectOfType<Player>().transform;

        alertObject.SetActive(false);
    }

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        StartCoroutine(StartAttack());
    }

    private IEnumerator StartAttack()
    {
        alertObject.SetActive(true);
        Vector3 newPos = new(player.position.x, alertObject.transform.position.y, player.transform.position.z);
        alertObject.transform.position = newPos;

        yield return new WaitForSeconds(timerToAlert);

        effectAnimator.Play("fireInGround");

        yield return new WaitForSeconds(0.7f);

        alertObject.SetActive(false);

        fireBoss.ChangeState(fireBoss.idleState);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }
}
