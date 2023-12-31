using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class player_movement : MonoBehaviour
{
    [SerializeField] float move_vector;
    [SerializeField] float move_speed;

    Rigidbody2D rigib_body;
    [SerializeField] float jump_speed;
    [SerializeField] float gravity;

    [SerializeField] private LayerMask ground;
    [SerializeField] private bool is_on_ground;

    private Animator animator;
    private SpriteRenderer sprite_renderer;

    private AudioSource player_sound;
    public bool on_pushing;
    public bool next_to_block;
    public bool die;
    [SerializeField] private LayerMask block_mask;

    public bool link_dead_bool;
    public bool dead_screen;
    public game_logic game_logic;

    public GameObject link_start;

    private float initial_x;
    private float end_x;

    void OnMove(InputValue value)
    {
        move_vector = value.Get<float>();
    }

    public void translate_link_to_start()
    {
        transform.position = link_start.transform.position;
    }

    void OnJump()
    {
        jump();
    }

    void jump()
    {
        if (is_on_ground & !link_dead_bool & game_logic.running)
        {
            player_sound.Play();
            rigib_body.AddForce(Vector2.up * jump_speed, ForceMode2D.Impulse);
        }
    }

    //private void swiping()
    //{
    //    //Touch touch = Input.GetTouch(0);
    //    //if (Input.touchCount > 0)
    //    //{
    //    if (touch.phase == UnityEngine.TouchPhase.Began)
    //    {
    //        initial_x = touch.position.x;
    //    }
    //    if (touch.phase == UnityEngine.TouchPhase.Ended)
    //    {
    //        end_x = touch.position.x;
    //        if( initial_x > end_x)
    //        {
    //            move_vector = 1;
    //        }
    //        else if (initial_x < end_x)
    //        {
    //            move_vector = -1;
    //        }
    //        else
    //        {
    //            move_vector = 0;
    //        }
    //    }
    //    //}
    //}

    void Update()
    {
        //swiping();

        is_link_dead();
        if (!link_dead_bool & game_logic.running)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
            {
                jump();
            }

            Debug.DrawRay(this.transform.position, Vector2.right * 1.2f, Color.blue);
            Debug.DrawRay(this.transform.position, Vector2.down * 2.0f, Color.red);
            Debug.DrawRay(this.transform.position + (new Vector3(1f, 0, 0)), Vector2.down * 2.0f, Color.red);
            Debug.DrawRay(this.transform.position + (new Vector3(-1f, 0, 0)), Vector2.down * 2.0f, Color.red);
            is_character_on_floor();
            is_near_block();
            transform.Translate(new Vector3(move_vector, 0, 0) * move_speed * Time.deltaTime);
            if (move_vector == 0.0f)
            {
                animator.SetBool("isRunning", false);
            }
            else
            {
                animator.SetBool("isRunning", true);
                if (move_vector > 0)
                {
                    sprite_renderer.flipX = true;
                }
                else
                {
                    sprite_renderer.flipX = false;
                }

            }
            if (next_to_block & is_on_ground)
            {
                animator.SetBool("afterBlock", true);
            }
            else
            {
                animator.SetBool("afterBlock", false);
            }
        }
        else
        {
            if (!dead_screen)
            {
                //animator.SetBool("isDead", true);
                Debug.Log("AHORA SI ME MORI CARNAL");

            }
            dead_screen = true;
        }
        
    }
    void is_character_on_floor()
    {
        if (
            Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, ground)
            || (Physics2D.Raycast(this.transform.position + (new Vector3(1f, 0, 0)), Vector2.down, 2.0f, ground))
            || (Physics2D.Raycast(this.transform.position + (new Vector3(-1f, 0, 0)), Vector2.down, 2.0f, ground))
           )
        {
            is_on_ground = true;
            animator.SetBool("onAir", false);
        }
        else
        {
            is_on_ground = false;
            animator.SetBool("onAir", true);
        }
    }
    void is_near_block()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.right, 1.2f, block_mask))
        {
            next_to_block = true;
        }
        else
        {
            next_to_block = false;
        }
    }

    void is_link_dead()
    {
        link_dead_bool = game_logic.is_link_dead;
        if (link_dead_bool)
        {
            animator.SetBool("isDead", true);
        }
        else
        {
            animator.SetBool("isDead", false);
        }
        //dead_screen = game_logic.dead_screen;
    }

    private void Awake()
    {
        game_logic = FindObjectOfType<game_logic>();
        link_dead_bool = game_logic.is_link_dead;
        dead_screen = game_logic.dead_screen;
        on_pushing = false;
        rigib_body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        rigib_body.gravityScale = 4.7f;
        gravity = 4;
        move_speed = 10;
        jump_speed = 20;
        player_sound = GetComponent<AudioSource>();
        translate_link_to_start();


    }

    private void Start()
    {
        Application.targetFrameRate = 240;
    }
}
