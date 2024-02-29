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

    [Header("Map Transition")]
    public List<GameObject> maps = new List<GameObject>();

  
    private void Start()
    {
        ChangeMap();
        foreach (RoomTransitionCollider rt in portals)
        {
            rt.OnMapTransition += ActiveMap;
        } 
    }

    public void ChangeMap()
    {
        portals.Clear();
        points.Clear();

        points = FindObjectsByType<TeleportPoints>(FindObjectsInactive.Include,FindObjectsSortMode.None).ToList();
        portals = FindObjectsByType<RoomTransitionCollider>(FindObjectsInactive.Include, FindObjectsSortMode.None).ToList();

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

    public void ActiveMap(int id)
    {
        foreach(GameObject m in maps)
        {
            m.SetActive(false);
        }

        maps[id].SetActive(true);
        ChangeMap();
    }


    private void OnDestroy()
    {
        foreach (RoomTransitionCollider rt in portals)
        {
            rt.OnMapTransition -= ActiveMap;
        }
    }
}
