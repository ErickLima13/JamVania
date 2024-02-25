using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;

public class InSceneTransitionSettings : MonoBehaviour
{
    public static InSceneTransitionSettings Instance;
    public TransitionSettings transitionSettings;
    public float transitionDuration;
    private void Awake()
    {
        Instance = this;
    }

}
