using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class i_tween_example : MonoBehaviour
{
    public Transform target;            // Objeto que se movera
    public float move_duration;         // Duracion de animacion en segundos


    private void Start()
    {
        move_duration = 2.0f;

        if (target == null)
        {
            Debug.Log("No hay target, selecciona uno");
            return;
        }

        // Move Game Object de punto A a punto B
        Hashtable move_args = new Hashtable();
        move_args.Add("position", target.position);
        move_args.Add("time", move_duration);
        move_args.Add("easetype", iTween.EaseType.easeInOutQuad);
        iTween.MoveTo(gameObject, move_args);

        // Rotar un Game Object de una rotacion A a una rotacion B
        Hashtable rotate_args = new Hashtable();
        rotate_args.Add("rotation", new Vector3(0.0f, 180.0f, 0.0f));
        rotate_args.Add("time", move_duration);
        rotate_args.Add("easetype", iTween.EaseType.easeInOutQuad);
        iTween.RotateTo(gameObject, rotate_args);

        // Rotar un Game Object de una rotacion A a una rotacion B
        Hashtable rotate_args2 = new Hashtable();
        rotate_args2.Add("rotation", new Vector3(0.0f, 0.0f, 180.0f));
        rotate_args2.Add("time", move_duration);
        rotate_args2.Add("easetype", iTween.EaseType.easeInOutQuad);
        iTween.RotateTo(gameObject, rotate_args2);

        // Cambiar escala 
        Hashtable scale_args = new Hashtable();
        scale_args.Add("scale", new Vector3(2.0f, 2.0f, 2.0f));
        scale_args.Add("time", move_duration);
        scale_args.Add("easetype", iTween.EaseType.easeInOutQuad);
        iTween.ScaleTo(gameObject, scale_args);

        // Fade out 
        Hashtable fade_args = new Hashtable();
        fade_args.Add("alpha", 1);
        fade_args.Add("time", move_duration);
        fade_args.Add("easetype", iTween.EaseType.easeInOutQuad);
        iTween.FadeTo(gameObject, fade_args);

        // Add.("looptype", ITween.LoopType.pingpong)


    }
}
