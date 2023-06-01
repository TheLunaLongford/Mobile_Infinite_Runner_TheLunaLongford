using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_background : MonoBehaviour
{
    [SerializeField] string dificultad;
    [SerializeField] GameObject link;
    [SerializeField] GameObject bg_obj;
    SpriteRenderer bg;
    [SerializeField] Sprite bg_easy;
    [SerializeField] Sprite bg_med;
    [SerializeField] Sprite bg_hard;
    [SerializeField] GameObject music_box;
    [SerializeField] AudioSource music_player;
    [SerializeField] AudioClip bg_music_easy;
    [SerializeField] AudioClip bg_music_med;
    [SerializeField] AudioClip bg_music_hard;


    // Start is called before the first frame update
    void Start()
    {
        dificultad = PlayerPrefs.GetString("dificulty");

        bg = bg_obj.GetComponent<SpriteRenderer>();
        bg.sprite = get_bg_image();

        music_player = music_box.GetComponent<AudioSource>();
        music_player.clip = get_bg_music();
        music_player.Play();
        Instantiate(link);
    }

    Sprite get_bg_image()
    {
        switch (dificultad)
        {
            case "easy":
                return bg_easy;
            case "medium":
                return bg_med;
            case "hard":
                return bg_hard;
        }
        return bg_easy;
    }

    AudioClip get_bg_music()
    {
        switch (dificultad)
        {
            case "easy":
                return bg_music_easy;
            case "medium":
                return bg_music_med;
            case "hard":
                return bg_music_hard;
        }
        return bg_music_easy;
    }

}
