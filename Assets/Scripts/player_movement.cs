using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    [SerializeField] float move_vector;
    [SerializeField] float move_speed;

    private void OnMove(InputValue value)
    {
        //move_vector = new Vector2((float)value.Get(Ve), 0);
        move_vector = value.Get<float>();

    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(move_vector, 0, 0) * move_speed * Time.deltaTime);
    }
}
