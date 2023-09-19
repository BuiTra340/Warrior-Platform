using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip attack;
    public AudioClip background;
    public AudioClip hoihp;
    public AudioClip Ncapthanhcong;
    public AudioClip Ncapthatbai;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip audioclip)
    {
        sfxSource.PlayOneShot(audioclip);
    }
}
