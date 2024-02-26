using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;
using Cinemachine;

public class RoomTransitionCollider : MonoBehaviour
{
    public CinemachineVirtualCamera transitionToCamera;
    public Transform characterTeleportPoint;
    public Vector2 velocityToApplyOnTeleport;
    public Transform player;
    
    public string playerTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            player = collision.transform;
            TeleportPlayer();
        }
    }

    public void TeleportPlayer()
    {
        //Entrar em state de "preso"
        Player p = player.GetComponent<Player>();
        p.StateMachine.ChangeState(p.TransitionState);
        TransitionManager.Instance().onTransitionCutPointReached += FinishTeleport;
        TransitionManager.Instance().onTransitionEnd += ReleasePlayer;
        TransitionManager.Instance().Transition(InSceneTransitionSettings.Instance.transitionSettings, InSceneTransitionSettings.Instance.transitionDuration);
    }
    public void FinishTeleport()
    {
        TransitionManager.Instance().onTransitionCutPointReached -= FinishTeleport;
        //CameraManager.Instance.EnableCamera(transitionToCamera);
        player.transform.position = characterTeleportPoint.position;
    }
    public void ReleasePlayer()
    {
        TransitionManager.Instance().onTransitionEnd -= ReleasePlayer;
        Player p = player.GetComponent<Player>();
        p.StateMachine.ChangeState(p.IdleState);
        player.GetComponent<Rigidbody2D>().AddForce(velocityToApplyOnTeleport, ForceMode2D.Impulse);
    }
}
