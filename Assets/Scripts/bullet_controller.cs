using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controller : MonoBehaviour
{
    public float speed;
    public Transform dead_point;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void Start()
    {
        speed = 5.0f;
    }
}
