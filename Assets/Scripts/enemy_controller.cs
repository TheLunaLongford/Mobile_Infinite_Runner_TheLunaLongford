using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour
{
    public GameObject bullet_prefab;
    public Transform fire_point;

    public float fire_Rate;
    public float next_fire_time;


    private void Start()
    {
        fire_Rate = 2.0f;

    }

    private void Update()
    {
        if (Time.time > next_fire_time)
        {
            shoot();
            next_fire_time = Time.time + 1.0f / fire_Rate;
        }
    }

    private void shoot()
    {
        Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
    }

}
