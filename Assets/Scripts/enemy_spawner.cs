using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField] GameObject bloque;
    private int cantidad_bloque = 5;
    private int contador_bloque = 0;
    List<GameObject> bloques_guardados = new List<GameObject>();

    [SerializeField] GameObject rupee;
    private int cantidad_rupee = 5;
    private int contador_rupee = 0;
    List<GameObject> rupee_guardados = new List<GameObject>();

    int[] contadores = new int[2];
    // 0: bloque
    // 1: rupee


    [SerializeField] bool maquina_activa;
    [SerializeField] float spawning_time;

    void Start()
    {
        fill_contadores();
        maquina_activa = false;
        spawning_time = 5.0f;

        inicializar_objetos(bloque, bloques_guardados, cantidad_bloque);
        inicializar_objetos(rupee, rupee_guardados, cantidad_rupee);
        start_spawning();
    }

    void fill_contadores()
    {
        for ( int i = 0; i < contadores.Length; i++)
        {
            contadores[i] = 0;
        }
    }

    void inicializar_objetos(GameObject objeto, List<GameObject> lista, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            lista.Add(Instantiate(objeto) as GameObject);
        }
    }

    void start_spawning()
    {
        Invoke("spawn_element", spawning_time);
    }

    void spawn_element()
    {
        // Instantiate(bloque);
        int elemento = Random.Range(0, 5);

        activar_elementos(elemento);

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

    void activar_elementos(int elemento)
    {
        switch (elemento)
        {
            case 0: // 
                siguiente_bloque("", 0.0f);
                break;
            case 1: //
                siguiente_bloque("up", 1.0f);
                break;
            case 2: //
                siguiente_bloque("", 0.0f);
                siguiente_bloque("up", 1.0f);
                break;
            case 3: //
                siguiente_bloque("", 0.0f);
                siguiente_bloque("up", 1.0f);
                siguiente_bloque("up", 2.0f);
                break;
            case 4: //
                siguiente_bloque("", 0.0f);
                siguiente_bloque("left", 1.0f);
                siguiente_bloque("up", 1.0f);
                break;
        }
    }

    void siguiente_bloque(string direccion, float veces)
    {
        bloques_guardados[contador_bloque].GetComponent<obj_movement>().moving = true;
        bloques_guardados[contador_bloque].GetComponent<obj_movement>().move_speed *= 1.05f;
        switch (direccion)
        {
            case "up":
                bloques_guardados[contador_bloque].transform.position += return_up_vector(veces);
                break;
            case "right":
                bloques_guardados[contador_bloque].transform.position += return_right_vector(veces);
                break;
            case "left":
                bloques_guardados[contador_bloque].transform.position += return_left_vector(veces);
                break;
        }
        contador_bloque++;
        contador_bloque = (contador_bloque >= bloques_guardados.Count) ? 0 : contador_bloque;
    }

    Vector3 return_up_vector(float veces)
    {
        return new Vector3(0, veces * 2.0f, 0); 
    }
    Vector3 return_right_vector(float veces)
    {
        return new Vector3(veces * 2.0f, 0, 0);
    }
    Vector3 return_left_vector(float veces)
    {
        return new Vector3(veces * -2.0f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
