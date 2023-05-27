using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_logic : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audio_background;
    void Start()
    {
        audio_background = GetComponent<AudioSource>();
        audio_background.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
