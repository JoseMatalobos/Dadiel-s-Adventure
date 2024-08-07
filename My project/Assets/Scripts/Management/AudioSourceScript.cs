using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    AudioSource asr;

    public void Start()
    {
        asr = GetComponent<AudioSource>();
    }
    public void StopMusic() 
    {
        asr.Stop();
    }
}
