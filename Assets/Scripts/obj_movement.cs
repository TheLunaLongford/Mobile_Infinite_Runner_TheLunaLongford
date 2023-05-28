using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_movement : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    [SerializeField] GameObject punto_inicial;
    [SerializeField] GameObject punto_final;
    public GameObject player;
    private Collider2D player_collider;

    private Rigidbody2D rb2d;
    private Rigidbody2D player_rb2d;
    public float move_speed;
    [SerializeField] bool touching_me;
    [SerializeField] bool trigger_me;
    [SerializeField] bool touching_me_by_side;
    public bool moving;
    public string que_soy;

    [SerializeField] private LayerMask player_mask;
    private AudioSource rupee_sound;

    void Start()
    {
        rupee_sound = GetComponent<AudioSource>();
        player_collider = player.GetComponent<Collider2D>(); 
        touching_me = false;
        moving = false;
        move_speed = 5.0f;
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = punto_inicial.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Debug.DrawRay(this.transform.position, Vector2.left * 2.0f, Color.red);
            is_touching_by_side();
            if (transform.position.x > punto_final.transform.position.x)
            {
                transform.Translate(new Vector3(-1, 0, 0) * move_speed * Time.deltaTime);
            }
            else
            {
                regresar_inicio();
            }
        }
        if (trigger_me)
        {
            // Aqui Recolectamos X cosa
            Debug.Log("Ahora si perro!");
            regresar_inicio();
            sonido_recolectable();
        }
        
    }

    private void sonido_recolectable()
    {
        switch (que_soy)
        {
            case "rupee":
                rupee_sound.Play();
                break;
        }
    }

    private void regresar_inicio()
    {
        transform.position = punto_inicial.transform.position;
        moving = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Aqui es cuando recien estas tocando el objeto
        touching_me = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Aqui es cuando ya no estas tocando al objeto
        touching_me = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger_me = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger_me = false;
    }

    void is_touching_by_side()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.left, 2.0f, player_mask))
        {
            touching_me_by_side = true;
        }
        else
        {
            touching_me_by_side = false;
        }
    }
}
