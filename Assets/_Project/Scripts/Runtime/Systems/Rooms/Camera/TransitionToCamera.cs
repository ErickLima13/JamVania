using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera newCam;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            print("chamei");
            CameraManager.Instance.EnableCamera(newCam);
        }
    }
}
