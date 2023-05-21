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


    void OnMove(InputValue value)
    {
        move_vector = value.Get<float>();
    }

    void OnJump()
    {
        rigib_body.AddForce(Vector2.up * jump_speed, ForceMode2D.Impulse);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(move_vector, 0, 0) * move_speed * Time.deltaTime);
    }

    private void Awake()
    {
        rigib_body = GetComponent<Rigidbody2D>();
        rigib_body.gravityScale = gravity = 4;
        move_speed = 10;
        jump_speed = 20;
    }
}
