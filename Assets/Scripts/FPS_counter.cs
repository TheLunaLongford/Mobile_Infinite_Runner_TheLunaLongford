using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_counter : MonoBehaviour
{
    public Text fps_text;
    public float delta_time;
    private float frame_counter;

    private void Start()
    {
        delta_time = 0.0f;
    }

    private void Update()
    {
        delta_time += (Time.deltaTime - delta_time) * 0.1f;
        float fps = 1.0f / delta_time;

        string cadena = string.Format("{0:0} FPS", fps);
        fps_text.text = cadena;
    }
}
