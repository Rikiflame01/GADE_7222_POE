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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            soundMap = new CustomHashmap<string, AudioClip>(audioClips.Count);
            foreach (AudioClip clip in audioClips)
            {
                soundMap.Add(clip.name, clip);
            }
        }
        else
        {
            Destroy(gameObject);
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
                case SceneName.BeginnerRace:
                    // PlaySound for BeginnerRace is not yet added
                    break;
                case SceneName.CheckpointRace:
                    // PlaySound for CheckpointRace is not yet added
                    break;
                case SceneName.AdvancedRace:
                    PlaySound("AdvancedSceneMusic");
                    break;
                case SceneName.CheckpointRaceDialogue:
                    // PlaySound for CheckpointRaceDialogue is not yet added
                    break;
                case SceneName.BeginnerRaceDialogue:
                    // PlaySound for BeginnerRaceDialogue is not yet added
                    break;
                case SceneName.AdvancedRaceDialogue:
                    // PlaySound for AdvancedRaceDialogue is not yet added
                    break;
                default:
                    // Handle any undefined scenes here Mr.M
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
}
