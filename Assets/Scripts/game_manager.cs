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
    // Start is called before the first frame update
    void Start()
    {
        estado_juego = 1;   // 1: Intro;    2:Start;    3:Dificultad;  4: Tutorial;    5: Game;   6: Pausa;   7: End;
        go_intro();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Screen_Intro.gameObject.SetActive(true);
        Screen_Start.gameObject.SetActive(false);
        Screen_Dificultad.gameObject.SetActive(true);
        Screen_Tutorial.gameObject.SetActive(false);
        Screen_Game.gameObject.SetActive(false);
        //Screen_Pausa.gameObject.SetActive(true);
        //Screen_End.gameObject.SetActive(true);
    }

    public void go_tutorial()
    {
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
