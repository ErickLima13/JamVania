using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttackState : EarthState
{
    public Vector3 initPos;

    public float attackThornDuration;

    public bool canJump;

    [SerializeField] private List<GameObject> thornAttacks = new();


    public override void Do()
    {
        base.Do();

        if (canJump)
        {
            JumpAtack();
        }
    }

    public override void Enter()
    {
        base.Enter();

        DisableAll();
        canJump = true;
        print("Jump");

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    public void JumpAtack()
    {
        earthBoss.transform.position = Vector3.MoveTowards(transform.position, initPos, bossData.speed * Time.deltaTime);

        if (earthBoss.transform.position == initPos)
        {
            canJump = false;
            StartCoroutine(JumpAttackCorrotine());
        }
    }

    public IEnumerator JumpAttackCorrotine()
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

        earthBoss.ChangeState(earthBoss.idleState);
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
