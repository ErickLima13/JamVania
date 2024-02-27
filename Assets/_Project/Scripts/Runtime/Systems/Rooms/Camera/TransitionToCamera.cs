using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera newCam;

    [SerializeField] private bool isBigRoom;

    [SerializeField] private int idInMap;

    private MiniMapController miniMapController;

    private void Start()
    {
        miniMapController = FindObjectOfType<MiniMapController>();

        if (isBigRoom)
        {
            Player player = FindObjectOfType<Player>();
            newCam.Follow = player.transform;
            newCam.LookAt = player.transform;   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            CameraManager.Instance.EnableCamera(newCam);
            miniMapController.EnterRoom(idInMap);
        }
    }
}
