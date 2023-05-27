using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_movement : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    [SerializeField] GameObject punto_inicial;
    [SerializeField] GameObject punto_final;
    [SerializeField] GameObject player;

    private Rigidbody2D rb2d;
    private Rigidbody2D player_rb2d;
    [SerializeField] float move_speed;
    [SerializeField] float push_speed;
    [SerializeField] bool touching_me;

    void Start()
    {
        touching_me = false;
        move_speed = 5.0f;
        push_speed = 500.0f;
        rb2d = GetComponent<Rigidbody2D>();
        player_rb2d = player.GetComponent<Rigidbody2D>();
        transform.position = punto_inicial.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * move_speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("weeeeeee");
        touching_me = true;
        player_rb2d.AddForce(Vector2.left * push_speed, ForceMode2D.Impulse);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("byeeeee");
        touching_me = false;
        player_rb2d.AddForce(Vector2.up * push_speed, ForceMode2D.Impulse);
    }
}
