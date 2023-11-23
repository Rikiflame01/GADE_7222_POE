using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    private AudioSource audioSource;
    public List<AudioClip> musicClips;

    private CustomHashmap<string, AudioClip> musicMap;

    void Awake()
    {
        SceneChangeNotifier.OnSceneChanged += HandleSceneChanged;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            musicMap = new CustomHashmap<string, AudioClip>(musicClips.Count);
            foreach (AudioClip clip in musicClips)
            {
                musicMap.Add(clip.name, clip);
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
        SwitchMusicOnSceneLoad();
    }

    private void SwitchMusicOnSceneLoad()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        SceneName currentSceneEnum;
        if (Enum.TryParse(sceneName, out currentSceneEnum))
        {
            switch (currentSceneEnum)
            {
                case SceneName.MainMenu:
                    PlayMusic("OpenTheme");
                    break;
                case SceneName.BeginnerRace:
                    PlayMusic("RaceStarts");
                    break;
                case SceneName.CheckpointRace:
                    PlayMusic("RaceStarts");
                    break;
                case SceneName.AdvancedRace:
                    PlayMusic("RaceStarts");
                    break;
                case SceneName.CheckpointRaceDialogue:
                    //unhandled
                    break;
                case SceneName.BeginnerRaceDialogue:
                    //unhandled
                    break;
                case SceneName.AdvancedRaceDialogue:
                    //unhandled
                    break;
                default:
                    break;
            }
        }
    }

    public void PlayMusic(string musicName)
    {
        audioSource.Stop(); // Stop any currently playing music
        AudioClip clip = musicMap.Get(musicName);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
