using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveState : WaterState
{
    [SerializeField] private List<GameObject> waves = new();

    [SerializeField] private Transform wavesTarget;

    [SerializeField] private float speedWaves;

    [SerializeField] private List<Vector3> initPos = new();

    public bool canMove;

    public override void Do()
    {
        base.Do();

        WaveAttack();

    }

    public override void Enter()
    {
        base.Enter();

        canMove = true;
    }

    public override void Exit()
    {
        base.Exit();

        waves[0].transform.localPosition = initPos[0];
        waves[1].transform.localPosition = initPos[1];
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void WaveAttack()
    {
        foreach (GameObject wave in waves)
        {
            wave.SetActive(true);
            wave.transform.position = Vector3.MoveTowards(wave.transform.position, wavesTarget.position, speedWaves * Time.deltaTime);

            if (wave.transform.position == wavesTarget.transform.position)
            {
                wave.SetActive(false);
                StartCoroutine(MoveWave());  
            }
        }
    }

    private IEnumerator MoveWave()
    {
        yield return new WaitForSeconds(0.5f);

        if (canMove)
        {
            canMove = false;
            waterBoss.ChangeState(waterBoss.idleState);  
        }
    }
}