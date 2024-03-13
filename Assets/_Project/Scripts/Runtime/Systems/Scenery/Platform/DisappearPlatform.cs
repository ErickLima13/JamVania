using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    [SerializeField] private float timerToDisappear;

    [SerializeField] private BoxCollider2D box;

    private Transform playerPos;

    private Animator animator;

    public bool isActive;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (!isActive)
            {
                playerPos = player.transform;
                playerPos.SetParent(transform);
                StartCoroutine(DelayTime());
            }
       
        }
    }

    private IEnumerator DelayTime()
    {
        isActive = true;
        animator.Play("fade");
        yield return new WaitForSeconds(timerToDisappear);
        box.enabled = false;
        playerPos.SetParent(null);

        yield return new WaitForSeconds(2);
        box.enabled = true;
        animator.Play("state");
        isActive = false;
    }


}
