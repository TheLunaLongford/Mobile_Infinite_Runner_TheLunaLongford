using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_movement : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    [SerializeField] GameObject punto_inicial;
    [SerializeField] GameObject punto_final;
    public GameObject player;

    private Rigidbody2D rb2d;
    private Rigidbody2D player_rb2d;
    public float move_speed;
    [SerializeField] bool touching_me;
    [SerializeField] bool touching_me_by_side;
    public bool moving;

    [SerializeField] private LayerMask player_mask;

    void Start()
    {
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
                transform.position = punto_inicial.transform.position;
                moving = false;
            }
        }
        
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
