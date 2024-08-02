using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamblerReaction : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] entryaudioClips;
    public AudioClip[] happyaudioClips;
    public AudioClip[] sadaudioClips;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomEntryClip();
    }

    public void SadReaction()
    {
        animator.SetTrigger("Fail");
        PlayRandomSadClip();
    }

    public void HappyReaction()
    {
        animator.SetTrigger("Won");
        PlayRandomHappyClip();
    }

    void PlayRandomHappyClip()
    {
        if (happyaudioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, happyaudioClips.Length);
            audioSource.clip = happyaudioClips[randomIndex];
            audioSource.Play();
        }
    }

    void PlayRandomSadClip()
    {
        if (sadaudioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, sadaudioClips.Length);
            audioSource.clip = sadaudioClips[randomIndex];
            audioSource.Play();
        }
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
