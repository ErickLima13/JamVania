using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private List<SaveController> savePos = new();

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        if (PlayerPrefs.HasKey("idPos"))
        {
           // TransitionManager.Instance().Transition(InSceneTransitionSettings.Instance.transitionSettings, InSceneTransitionSettings.Instance.transitionDuration);
            LoadGame(PlayerPrefs.GetInt("idPos"));
        }
    }

    public void LoadGame(int id)
    {
        player.transform.position = savePos[id].transform.position + Vector3.right;

        print("LOAD");
    }

    [ContextMenu("Delete Load")]
    private void DeleteLoad()
    {
        PlayerPrefs.DeleteKey("idPos");

        print("RESET");
    }
}
