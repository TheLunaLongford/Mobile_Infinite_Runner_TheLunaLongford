using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linea_progreso : MonoBehaviour
{
    [SerializeField] GameObject inicio;
    [SerializeField] GameObject final;

    [SerializeField] GameObject link;
    public bool avanzando;
    // Start is called before the first frame update
    void Start()
    {
        link.transform.position = inicio.transform.position;
        avanzando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (avanzando)
        {
            if (link.transform.position.x < final.transform.position.x)
            {
                link.transform.Translate(new Vector3(1, 0, 0) * 1.0f * Time.deltaTime);
            }
        }
    }
}
