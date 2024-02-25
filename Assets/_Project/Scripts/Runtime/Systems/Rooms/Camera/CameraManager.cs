using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public List<CinemachineVirtualCamera> allSceneCameras;
    private void Awake()
    {
        Instance = this;
    }
    public void EnableCamera(CinemachineVirtualCamera newCamera)
    {
        List<CinemachineVirtualCamera> allCamerasClones = allSceneCameras.ToList();
        allCamerasClones.Remove(newCamera);
        DisableOtherCameras(allCamerasClones);
        newCamera.gameObject.SetActive(true);
    }
    public void DisableOtherCameras(List<CinemachineVirtualCamera> camerasToDisable)
    {
        foreach (CinemachineVirtualCamera c in camerasToDisable)
        {
            c.gameObject.SetActive(false);
        }
    }
}
