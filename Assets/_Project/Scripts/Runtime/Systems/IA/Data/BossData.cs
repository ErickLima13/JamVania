using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossData", menuName = "Data/Boss Data/Base Data")]

public class BossData : ScriptableObject
{
    public float wallDistance;
    public float speed;
}
