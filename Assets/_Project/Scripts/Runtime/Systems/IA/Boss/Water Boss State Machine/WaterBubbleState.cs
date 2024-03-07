using System.Collections;
using UnityEngine;

public class WaterBubbleState : WaterState
{
    [SerializeField] private GameObject bubblePrefab;

    private bool isLeft;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        ShootBubbles();
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void ShootBubbles()
    {
        StartCoroutine(DelayShoot());
    }

    private IEnumerator DelayShoot()
    {
        int rand = Random.Range(0, 10);
        isLeft = rand > 5;

        float scaleX = waterBoss.transform.localScale.x;

        if (isLeft)
        {
            scaleX *= -1f;
        }
        else
        {
            scaleX *= -1f;
        }

        waterBoss.transform.localScale = new(scaleX, waterBoss.transform.localScale.y, waterBoss.transform.localScale.z);

        yield return new WaitForSeconds(0.5f);

        GameObject temp = Instantiate(bubblePrefab, transform.position, waterBoss.transform.rotation);
        temp.transform.localScale = new(temp.transform.localScale.x * waterBoss.transform.localScale.x, temp.transform.localScale.y);

        yield return new WaitForSeconds(1f);

        waterBoss.ChangeState(waterBoss.idleState);

        
    }
}
