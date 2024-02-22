using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField] private Transform[] targetsPos;

    [SerializeField] private float speed;

    [SerializeField] private Transform targetToMove;

    public int idPos;

    private Transform playerPos;

    private void Start()
    {
        targetToMove.position = targetsPos[idPos].position;
    }

    private void Update()
    {
        targetToMove.position = Vector3.MoveTowards(targetToMove.position, targetsPos[idPos].position, speed * Time.deltaTime);

        if (targetToMove.position == targetsPos[idPos].position)
        {
            idPos++;
            if (idPos >= targetsPos.Length)
            {
                idPos = 0;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            playerPos = player.transform;
            playerPos.SetParent(transform,true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerPos.SetParent(null);
    }
}
