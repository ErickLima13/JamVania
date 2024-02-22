using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    [SerializeField] private float timerToDisappear;

    private Transform playerPos;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            playerPos = player.transform;
            playerPos.SetParent(transform);
            StartCoroutine(DelayTime());
        }
    }

    private IEnumerator DelayTime()
    {
        animator.Play("fade");
        yield return new WaitForSeconds(timerToDisappear);

        playerPos.SetParent(null);
        Destroy(gameObject);
    }


}
