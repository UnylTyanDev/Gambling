using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] entryaudioClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomEntryClip();
    }

    void PlayRandomEntryClip()
    {
        if (entryaudioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, entryaudioClips.Length);
            audioSource.clip = entryaudioClips[randomIndex];
            audioSource.Play();
        }
    }
}
