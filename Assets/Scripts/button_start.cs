using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_start : MonoBehaviour
{
    AudioSource audio;
    public Canvas canvas;

    [SerializeField] GameObject link;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Instantiate(link);
    }

    public void press_start()
    {
        audio.Play();
        Invoke("descargar_canvas", 2);
        //canvas.gameObject.SetActive(false);
    }

    void descargar_canvas()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
