using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class mixer : MonoBehaviour
{
    public AudioMixer audio_mixer;

    public void set_BGM_volume(float volume)
    {
        audio_mixer.SetFloat("VolumeBGM", volume);
    }
}
