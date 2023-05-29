using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro_animation : MonoBehaviour
{
    [SerializeField] GameObject inicio;
    [SerializeField] GameObject final;

    [SerializeField] GameObject link;
    private bool direccion;
    [SerializeField] private float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 3.0f;
        link.transform.position = inicio.transform.position;
        direccion = true; // true -> derecha; false -> izquierda
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion)
        {
            link.GetComponent<SpriteRenderer>().flipX = true;
            if (link.transform.position.x < final.transform.position.x)
            {
                link.transform.Translate(new Vector3(1, 0, 0) * velocidad * Time.deltaTime);
            }
            else
            {
                direccion = false;
                
            }
        }
        else
        {
            link.GetComponent<SpriteRenderer>().flipX = false;
            if (link.transform.position.x > inicio.transform.position.x)
            {
                link.transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);
            }
            else
            {
                direccion = true;
            }
        }
    }
}
