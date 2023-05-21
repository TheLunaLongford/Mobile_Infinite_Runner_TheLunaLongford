using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    [SerializeField] GameObject mono;
    // Start is called before the first frame update
    void Start()
    {
        
        //if (Gamepad.current.aButton.wasPressedThisFrame)
        //{
        //    Debug.Log("A button was pressed");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Instantiate(mono);
        //}

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Debug.Log("A key was pressed");
        }
    }
}
