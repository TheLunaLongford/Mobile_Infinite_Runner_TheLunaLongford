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

    [SerializeField] GameObject rupee_azul;
    private int cantidad_rupee_azul = 2;
    private int contador_rupee_azul = 0;
    List<GameObject> rupee_azul_guardados = new List<GameObject>();

    [SerializeField] GameObject punto_inicial;

    int[] contadores = new int[2];
    // 0: bloque
    // 1: green rupee
    // 2: bluee rupee


    [SerializeField] bool maquina_activa;
    [SerializeField] float spawning_time;
    [SerializeField] float move_speed;

    void Start()
    {
        fill_contadores();
        maquina_activa = false;
        spawning_time = 5.0f;
        move_speed = 5.0f;

        inicializar_objetos(bloque, bloques_guardados, cantidad_bloque);
        inicializar_objetos(rupee, rupee_guardados, cantidad_rupee);
        inicializar_objetos(rupee_azul, rupee_azul_guardados, cantidad_rupee_azul);

        
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
            //lista[i].transform.position = punto_inicial.transform.position + return_up_vector((float)(i + 1));
        }
    }

    void start_spawning()
    {
        Invoke("spawn_element", spawning_time);
    }

    void spawn_element()
    {
        // Instantiate(bloque);
        int elemento = Random.Range(0, 9);

        activar_elementos(elemento);

        spawning_time *= 0.95f;
        move_speed *= 1.05f;
        if (spawning_time > 1.0f)
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
            case 0: // Un bloque simple
                siguiente_bloque("", 0.0f);
                break;
            case 1: // Un bloque simple, pero arriba
                siguiente_bloque("up", 1.0f);
                break;
            case 2: // Dos bloques, uno simple y uno arriba
                siguiente_bloque("", 0.0f);
                siguiente_bloque("up", 1.0f);
                break;
            case 3: // Tres bloques, uno sumple, uno arriba, y otro mas arriba
                siguiente_bloque("", 0.0f);
                siguiente_bloque("up", 1.0f);
                siguiente_bloque("up", 2.0f);
                break;
            case 4: // Tres bloques, uno simple, uno a la izq, y otro mas arriba
                siguiente_bloque("", 0.0f);
                siguiente_bloque("left", 1.0f);
                siguiente_bloque("up", 1.0f);
                break;
            case 5: // Una Rupee simple
                siguiente_rupee("", 0.0f);
                break;
            case 6: // Una Rupee simple, mas arriba
                siguiente_rupee("up", 1.0f);
                break;
            case 7: // Una Rupee simple, mas mas arriba
                siguiente_rupee_azul("up", 3.0f);
                break;
            case 8: // Una Rupee simple, muy encima de un bloque
                siguiente_bloque("", 0.0f);
                siguiente_rupee_azul("up", 2.0f);
                break;
        }
    }

    void siguiente_bloque(string direccion, float veces)
    {
        bloques_guardados[contador_bloque].GetComponent<obj_movement>().moving = true;
        bloques_guardados[contador_bloque].GetComponent<obj_movement>().move_speed = move_speed;
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

    void siguiente_rupee(string direccion, float veces)
    {
        rupee_guardados[contador_rupee].GetComponent<obj_movement>().moving = true;
        rupee_guardados[contador_rupee].GetComponent<obj_movement>().move_speed = move_speed;
        switch (direccion)
        {
            case "up":
                rupee_guardados[contador_rupee].transform.position += return_up_vector(veces);
                break;
            case "right":
                rupee_guardados[contador_rupee].transform.position += return_right_vector(veces);
                break;
            case "left":
                rupee_guardados[contador_rupee].transform.position += return_left_vector(veces);
                break;
        }
        contador_rupee++;
        contador_rupee = (contador_rupee >= rupee_guardados.Count) ? 0 : contador_rupee;
    }

    void siguiente_rupee_azul(string direccion, float veces)
    {
        rupee_azul_guardados[contador_rupee_azul].GetComponent<obj_movement>().moving = true;
        rupee_azul_guardados[contador_rupee_azul].GetComponent<obj_movement>().move_speed = move_speed;
        switch (direccion)
        {
            case "up":
                rupee_azul_guardados[contador_rupee_azul].transform.position += return_up_vector(veces);
                break;
            case "right":
                rupee_azul_guardados[contador_rupee_azul].transform.position += return_right_vector(veces);
                break;
            case "left":
                rupee_azul_guardados[contador_rupee_azul].transform.position += return_left_vector(veces);
                break;
        }
        contador_rupee_azul++;
        contador_rupee_azul = (contador_rupee_azul >= rupee_azul_guardados.Count) ? 0 : contador_rupee_azul;
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
