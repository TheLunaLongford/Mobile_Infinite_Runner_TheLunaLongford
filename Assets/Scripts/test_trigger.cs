using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_trigger : MonoBehaviour
{

    public bool trigger_me;
    // Start is called before the first frame update
    void Start()
    {
        trigger_me = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger_me = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger_me = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
