using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_logic : MonoBehaviour
{
    public static game_logic share_intance;

    public bool running;
    public bool is_link_dead;
    public bool dead_screen;
    public bool is_paused;

    public Canvas Screen_Game;
    public Canvas Screen_Dead;

    public player_movement Link_player;
    public enemy_spawner enemy_spawner;

    public GameObject Link_start;
    public int score_partida;
    public int mejor_score;

    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        running = true;
        is_link_dead = false;
        is_paused = false;
        mejor_score = PlayerPrefs.GetInt("mejor_score");
        score_partida = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        //Link_player = Link.GetComponent<player_movement>();
        if (share_intance == null)
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
        Screen_Game.gameObject.SetActive(false);
        Screen_Game.gameObject.SetActive(true);
        // mover Link al inicio
        Link_player = FindObjectOfType<player_movement>();
        Link_player.translate_link_to_start();

        // Restaurar not dead a Link
        enemy_spawner = FindObjectOfType<enemy_spawner>();
        running = true;
        is_link_dead = false;

        // Restaurar valores iniciales de los parametros
        score_partida = 0;
        PlayerPrefs.SetInt("score_partida", score_partida);
        score.text = score_partida.ToString();

        // 
    }
}
