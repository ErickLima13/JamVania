using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemies : MonoBehaviour
{
    public GameObject panelHp;

    public Image hpBar;

    public float timerActive;

    private void Start()
    {
        panelHp.SetActive(false);
    }

    public void ShowHealth(float value)
    {
        hpBar.fillAmount = value;
        panelHp.SetActive(true);
        StartCoroutine(DelayPainel());
    }

    private IEnumerator DelayPainel()
    {
        yield return new WaitForSeconds(timerActive);
        panelHp.SetActive(false);
    }
}
