using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    private int estado_juego;

    public Canvas Screen_Intro;
    public Canvas Screen_Start;
    public Canvas Screen_Dificultad;
    public Canvas Screen_Tutorial;
    public Canvas Screen_Game;
    public Canvas Screen_Pausa;
    public Canvas Screen_End;

    public AudioClip sound_menu;
    private AudioSource sound_master;
    // Start is called before the first frame update
    void Start()
    {
        sound_master = GetComponent<AudioSource>();
        sound_master.playOnAwake = false;
        estado_juego = 1;   // 1: Intro;    2:Start;    3:Dificultad;  4: Tutorial;    5: Game;   6: Pausa;   7: End;
        go_intro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void play_menu_sound()
    {
        sound_master.clip = sound_menu;
        sound_master.Play();
    }

    public void go_intro()
    {
        Screen_Intro.gameObject.SetActive(true);
        Screen_Start.gameObject.SetActive(true);
        Screen_Dificultad.gameObject.SetActive(false);
        Screen_Tutorial.gameObject.SetActive(false);
        Screen_Game.gameObject.SetActive(false);

        //Screen_Pausa.gameObject.SetActive(true);
        //Screen_End.gameObject.SetActive(true);
    }

    public void go_dificultad()
    {
        play_menu_sound();
        Screen_Intro.gameObject.SetActive(true);
        Screen_Start.gameObject.SetActive(false);
        Screen_Dificultad.gameObject.SetActive(true);
        Screen_Tutorial.gameObject.SetActive(false);
        Screen_Game.gameObject.SetActive(false);
        //Screen_Pausa.gameObject.SetActive(true);
        //Screen_End.gameObject.SetActive(true);
    }

    public void dificulty_easy()
    {
        PlayerPrefs.SetString("dificulty", "easy");
        go_tutorial();
    }
    public void dificulty_medium()
    {
        PlayerPrefs.SetString("dificulty", "medium");
        go_tutorial();
    }
    public void dificulty_hard()
    {
        PlayerPrefs.SetString("dificulty", "hard");
        go_tutorial();
    }

    public void go_tutorial()
    {
        play_menu_sound();
        Screen_Intro.gameObject.SetActive(true);
        Screen_Start.gameObject.SetActive(false);
        Screen_Dificultad.gameObject.SetActive(false);
        Screen_Tutorial.gameObject.SetActive(true);
        Screen_Game.gameObject.SetActive(false);
        //Screen_Pausa.gameObject.SetActive(true);
        //Screen_End.gameObject.SetActive(true);
    }

    public void go_game()
    {
        play_menu_sound();
        Screen_Intro.gameObject.SetActive(false);
        Screen_Start.gameObject.SetActive(false);
        Screen_Dificultad.gameObject.SetActive(false);
        Screen_Tutorial.gameObject.SetActive(false);
        Screen_Game.gameObject.SetActive(true);
        //Screen_Pausa.gameObject.SetActive(true);
        //Screen_End.gameObject.SetActive(true);
        estado_juego = 5;
    }
}
