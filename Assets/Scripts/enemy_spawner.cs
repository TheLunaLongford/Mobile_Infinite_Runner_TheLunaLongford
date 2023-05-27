using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField] GameObject bloque;
    private int cantidad_bloque = 5;
    private int contador_bloque = 0;
    List<GameObject> bloques_guardados = new List<GameObject>();


    [SerializeField] bool maquina_activa;
    [SerializeField] float spawning_time;

    void Start()
    {
        maquina_activa = false;
        spawning_time = 5.0f;

        inicializar_bloques();
    }

    void inicializar_bloques()
    {
        for (int i = 0; i < cantidad_bloque; i++)
        {
            bloques_guardados.Add(Instantiate(bloque) as GameObject);
        }
        start_spawning();
    }

    void start_spawning()
    {
        Invoke("spawn_element", spawning_time);
    }

    void spawn_element()
    {
        // Instantiate(bloque);
        bloques_guardados[contador_bloque].GetComponent<obj_movement>().moving = true;
        
        bloques_guardados[contador_bloque].transform.position += return_up_vector();
        contador_bloque++;
        if(contador_bloque >= bloques_guardados.Count)
        {
            contador_bloque = 0;
        }

        spawning_time *= 0.95f;
        if(spawning_time > 1.0f)
        {
            Invoke("spawn_element", spawning_time);
        }
        else
        {
            Debug.Log("termine de spawnear");
        }
    }

    Vector3 return_up_vector()
    {
        return new Vector3(0, Random.Range(0, 2) * 2.0f, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
