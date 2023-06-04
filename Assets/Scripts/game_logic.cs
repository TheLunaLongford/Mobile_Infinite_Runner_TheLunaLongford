using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_logic : MonoBehaviour
{
    public static game_logic share_intance;

    public bool running;
    public bool is_link_dead;
    public bool dead_screen;
    public bool is_paused;

    public Canvas Screen_Game;
    public Canvas Screen_Dead;
    // Start is called before the first frame update
    void Start()
    {
        running = true;
        is_link_dead = false;
        is_paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if(share_intance == null)
        {
            share_intance = this;
        }
    }

    public void turn_on_dead_screen()
    {
        Screen_Dead.gameObject.SetActive(true);
        //Screen_Game.gameObject.SetActive(false);
    }

    public void turn_off_dead_screen()
    {
        Screen_Dead.gameObject.SetActive(false);
        //Screen_Game.gameObject.SetActive(true);
    }
}
