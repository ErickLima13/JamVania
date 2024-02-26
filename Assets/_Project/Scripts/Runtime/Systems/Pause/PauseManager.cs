using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    public bool isPaused;
    private void Awake()
    {
        Instance = this;
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
