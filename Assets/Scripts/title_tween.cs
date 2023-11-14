using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_tween : MonoBehaviour
{
    public float move_duration;         // Duracion de animacion en segundos
    // Start is called before the first frame update
    void Start()
    {
        move_duration = 1.0f;

        // Cambiar escala 
        Hashtable scale_args = new Hashtable();
        scale_args.Add("scale", new Vector3(70.0f, 70.0f, 70.0f));
        scale_args.Add("time", move_duration);
        scale_args.Add("easetype", iTween.EaseType.easeInOutQuad);
        scale_args.Add("looptype", iTween.LoopType.pingPong);
        iTween.ScaleTo(gameObject, scale_args);

        // Cambiar rotar pokito 
        Hashtable rotate_args = new Hashtable();
        rotate_args.Add("rotation", new Vector3(30.0f, 30.0f, 0.0f));
        rotate_args.Add("time", move_duration);
        rotate_args.Add("easetype", iTween.EaseType.easeInOutQuad);
        rotate_args.Add("looptype", iTween.LoopType.pingPong);
        iTween.RotateTo(gameObject, rotate_args);
    }

}
