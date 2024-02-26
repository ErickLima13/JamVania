using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [SerializeField] private int idPos;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            SaveGame();
        }
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("idPos", idPos);

        print("SAVE");
    }

  
}
