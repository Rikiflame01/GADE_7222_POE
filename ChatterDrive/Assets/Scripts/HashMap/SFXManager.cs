using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    private AudioSource audioSource;
    public List<AudioClip> audioClips; 

    private CustomHashmap<string, AudioClip> soundMap;

    void Awake()
    {
        SceneChangeNotifier.OnSceneChanged += HandleSceneChanged;
        audioSource = GetComponent<AudioSource>();

        soundMap = new CustomHashmap<string, AudioClip>(audioClips.Count);
        foreach (AudioClip clip in audioClips)
        {
            soundMap.Add(clip.name, clip);
        }

    }
    private void OnDisable()
    {
        SceneChangeNotifier.OnSceneChanged -= HandleSceneChanged;
    }

    private void HandleSceneChanged(Scene newScene)
    {
        SwitchOnSceneLoad();
    }

    private void SwitchOnSceneLoad()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        SceneName currentSceneEnum;
        if (Enum.TryParse(sceneName, out currentSceneEnum))
        {
            switch (currentSceneEnum)
            {
                case SceneName.MainMenu:
                    PlaySound("MMMusic");
                    break;
                case SceneName.BeginnerRaceDialogue:
                    PlaySound("DialogNext");
                    break;

            }
        }
    }

    public void PlaySound(string soundName)
    {
        audioSource.Stop(); // Stop any currently playing audio
        AudioClip clip = soundMap.Get(soundName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
    public void PlayLoudSound(string soundName)
    {
        int volume = 3;
        audioSource.Stop(); // Stop any currently playing audio
        AudioClip clip = soundMap.Get(soundName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
