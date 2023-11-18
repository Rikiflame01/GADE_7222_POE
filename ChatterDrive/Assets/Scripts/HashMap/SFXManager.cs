using UnityEngine;
using System.Collections.Generic;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    private AudioSource audioSource;
    public List<AudioClip> audioClips; 

    private CustomHashmap<string, AudioClip> soundMap;

    void Awake()
    {
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

        if (true)
        {
            SFXManager.Instance.PlaySound("GameMusic");
        }
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = soundMap.Get(soundName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
