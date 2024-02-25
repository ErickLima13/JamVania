using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData",menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    public float speed = 0.8f;
    public float jumpForce = 3;
    public float dashTimer = 2;
    public float dashForce = 1.6f;
    public float gravityScale = 1;
    public float maxFallSpeed = -6;
    public int damage = 1;

    public bool canDash;
    public bool canDoubleJump;


    [Header("Power Ups")]
    public bool dashEnable;
    public bool doubleJumpEnable;

}
