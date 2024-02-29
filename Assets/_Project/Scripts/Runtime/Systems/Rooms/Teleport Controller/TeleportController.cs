using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TeleportController : MonoBehaviour
{
    public List<TeleportPoints> points = new List<TeleportPoints>();
    public List<RoomTransitionCollider> portals = new List<RoomTransitionCollider>();

  
    private void Start()
    {
        points = FindObjectsOfType<TeleportPoints>().ToList();
        portals = FindObjectsOfType<RoomTransitionCollider>().ToList();

        points = points.OrderByDescending(p => p.idPoint).ToList();
        portals = portals.OrderByDescending(p => p.idPortal).ToList();

        for (int i = 0; i < points.Count; i++)
        {
            if (points[i].idPoint == portals[i].idPortal)
            {
                portals[i].characterTeleportPoint = points[i].transform;
                portals[i].transitionToCamera = points[i].myCam;
                print(i);
            }

        }
    }

}
