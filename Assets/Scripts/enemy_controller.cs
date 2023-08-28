using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public GameObject player;

    public GameObject proyectile;
    public Transform proyectile_spawn_point;
    public float proyectile_speed;

    public GameObject power_up_prefab;
    public float fire_rate;
    private int bullets_to_Skip;
    private int bullets_skipped;
    private float last_shoot_time;


    private void Start()
    {
        fire_rate = 1.5f;
        bullets_to_Skip = 3;
        bullets_skipped = 0;
        last_shoot_time = Time.time;
        proyectile_speed = 10.0f;
    }

    private void Update()
    {
        if (Time.time - last_shoot_time >= fire_rate)
        {
            Shoot();
            last_shoot_time = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 shoot_direction = (player.transform.position - transform.position).normalized;
        GameObject balita = Instantiate(proyectile, proyectile_spawn_point.position, Quaternion.identity);
        Rigidbody2D rb = balita.GetComponent<Rigidbody2D>();
        rb.velocity = shoot_direction * proyectile_speed;
    }

    private void drop_power_up()
    {
        Instantiate(power_up_prefab, transform.position, Quaternion.identity);
    }


}
