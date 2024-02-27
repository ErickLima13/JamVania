using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private GameObject playerInMap;

    [SerializeField] private List<GameObject> roomsInMap = new();

    public void EnterRoom(int roomId)
    {
        playerInMap.transform.SetParent(roomsInMap[roomId].transform);
        playerInMap.transform.localPosition = Vector3.zero;
    }


}
