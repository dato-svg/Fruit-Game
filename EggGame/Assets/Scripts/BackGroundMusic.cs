using System;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public static BackGroundMusic instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    
    private int currentClipIndex = 0;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    private void PlayNextClip()
    {
        if (clips.Length == 0) return;

        audioSource.clip = clips[currentClipIndex];
        audioSource.Play();

        currentClipIndex = (currentClipIndex + 1) % clips.Length;
    }
}
