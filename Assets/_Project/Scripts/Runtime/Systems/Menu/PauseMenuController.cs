using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject menuObject;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(UserInput.Instance.Pause_Input_Pressed && !PauseManager.Instance.isPaused)
        {
            OpenPauseMenu();
        }
        if (UserInput.Instance.UI_Pause_Input_Pressed && PauseManager.Instance.isPaused)
        {
            ClosePauseMenu();
        }
    }
    public void OpenPauseMenu()
    {
        PauseManager.Instance.PauseGame();
        UserInput.PlayerInput.SwitchCurrentActionMap("UI");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuObject.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        PauseManager.Instance.UnPauseGame();
        UserInput.PlayerInput.SwitchCurrentActionMap("PlayerActions");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuObject.SetActive(false);
    }
}
