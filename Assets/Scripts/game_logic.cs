using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_logic : MonoBehaviour
{
    public static game_logic share_intance;

    public bool running;
    // Start is called before the first frame update
    void Start()
    {
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if(share_intance == null)
        {
            share_intance = this;
        }
    }
}
