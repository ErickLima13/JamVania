using EasyTransition;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private InSceneTransitionSettings settings;

    [SerializeField] private List<Button> menuButtons;

    [SerializeField] private Slider sliderVolMusic;
    [SerializeField] private Slider sliderVolEffects;

    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        LoadVol();

        settings = InSceneTransitionSettings.Instance;
        menuButtons[0].Select();
    }

    public void ChangeScene(string sceneName)
    {
        TransitionManager.Instance().Transition(sceneName, settings.transitionSettings, settings.transitionDuration);
    }

    public void SetVolMusic(float vol)
    {
        sliderVolMusic.value = vol;
        audioMixer.SetFloat("Music", sliderVolMusic.value);

        PlayerPrefs.SetFloat("Music", sliderVolMusic.value);
    }

    public void SetVolEffects(float vol)
    {
        sliderVolEffects.value = vol;
        audioMixer.SetFloat("Effects", sliderVolEffects.value);

        PlayerPrefs.SetFloat("Effects", sliderVolEffects.value);
    }

    public void SelectObject(Selectable go)
    {
        go.Select();
    }

    private void LoadVol()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            sliderVolMusic.value = PlayerPrefs.GetFloat("Music");
        }

        if (PlayerPrefs.HasKey("Effects"))
        {
            sliderVolEffects.value = PlayerPrefs.GetFloat("Effects");
        }
    }
}
