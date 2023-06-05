using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class game_logic : MonoBehaviour
{
    public static game_logic share_intance;

    public bool running;
    public bool is_link_dead;
    public bool dead_screen;
    public bool is_paused;

    public Canvas Screen_Game;
    public Canvas Screen_Dead;
    public Canvas Screen_Pause;
    public Canvas Screen_End;

    public player_movement Link_player;
    public enemy_spawner enemy_spawner;

    public GameObject Link_start;
    public int score_partida;
    public int mejor_score;

    public TextMeshProUGUI score;
    public TextMeshProUGUI score_pause;

    public TextMeshProUGUI score_end;
    public TextMeshProUGUI score_end_high;

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
        retry_game();
    }
    
    public void retry_game()
    {
        Screen_Dead.gameObject.SetActive(false);
        Screen_Pause.gameObject.SetActive(false);
        Screen_End.gameObject.SetActive(false);
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
        enemy_spawner.spawning_time = PlayerPrefs.GetFloat("spawning_time");
        enemy_spawner.move_speed = PlayerPrefs.GetFloat("move_speed");
    }

    public void turn_on_pause_screen()
    {
        score_pause.text = PlayerPrefs.GetInt("score_partida").ToString();
        Screen_Pause.gameObject.SetActive(true);
        running = false;
        //Screen_Game.gameObject.SetActive(false);
    }

    public void turn_off_pause_screen()
    {
        Screen_Pause.gameObject.SetActive(false);
        running = true;
        //Screen_Game.gameObject.SetActive(false);
    }

    public void turn_on_end_screen()
    {
        int actual_score = PlayerPrefs.GetInt("score_partida");
        int high_score = PlayerPrefs.GetInt("high_score");

        if (actual_score > high_score)
        {
            PlayerPrefs.SetInt("high_score", actual_score);
            high_score = PlayerPrefs.GetInt("high_score");
        }

        score_end.text = actual_score.ToString();
        score_end_high.text = high_score.ToString();


        Screen_End.gameObject.SetActive(true);
        running = false;
        //Screen_Game.gameObject.SetActive(false);
    }

    public void turn_off_end_screen()
    {
        Screen_End.gameObject.SetActive(false);
        running = true;
        //Screen_Game.gameObject.SetActive(false);
    }

    public void retry_end_game()
    {
        retry_game();
        enemy_spawner.inicializar_todos();
        enemy_spawner.start_spawning();
    }

    public void reiniciar_juego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
