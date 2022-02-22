using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip wing;
    private static AudioSource audiosr;
    void Start()
    {
        wing = Resources.Load<AudioClip>("sfx_wing");

        audiosr = GetComponent<AudioSource>();
    }

    public static void PlaySound()
    {
        audiosr.PlayOneShot(wing);
    }
}
