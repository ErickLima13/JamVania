using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomTransitionCollider : MonoBehaviour
{
    public CinemachineVirtualCamera transitionToCamera;
    public Transform characterTeleportPoint;
    public Vector2 velocityToApplyOnTeleport;
    public string playerTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            CameraManager.Instance.EnableCamera(transitionToCamera);
            collision.transform.position = characterTeleportPoint.position;
            collision.GetComponent<Rigidbody2D>().AddForce(velocityToApplyOnTeleport, ForceMode2D.Impulse);
        }
    }
}
