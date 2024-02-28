using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFall : MonoBehaviour
{
    private LoadController loadController;

    private void Start()
    {
        loadController = FindObjectOfType<LoadController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player) )
        {
            StartCoroutine(DelayTime());
        }
    }

    private IEnumerator DelayTime()
    {
        TransitionManager.Instance().Transition(InSceneTransitionSettings.Instance.transitionSettings, InSceneTransitionSettings.Instance.transitionDuration);
       
        yield return new WaitForSeconds(0.2f);

        loadController.LoadGame(PlayerPrefs.GetInt("idPos"));
    }

}
