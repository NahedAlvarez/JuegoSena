using UnityEngine;
using System.Collections;

/// <summary>
/// Nose movement to turn
/// </summary>
public class PlayerV2 : MonoBehaviour
{
    public float turnSpeed = 1;
    public float MaxPlaneRotationDegrees = 45;


    protected Transform plane;
    // Use this for initialization
    void Start()
    {
        //guardamos una referencia de nuestra nave en nuestro script
        plane = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        transform.position = transform.position + transform.right * turnSpeed * horiz * Time.deltaTime;


        //Rotamos la nave en función del giro
        var r = plane.rotation.eulerAngles;
        // Hacemos un Lerp (media) de la posicion actual entre la rotacion min y max 
        r.z = Mathf.Lerp(-MaxPlaneRotationDegrees, MaxPlaneRotationDegrees, (-horiz + 1) / 2);
        //Aplicamos la rotacion a la nave
        plane.rotation = Quaternion.Lerp(plane.rotation, Quaternion.Euler(r), 0.1f);
    }
}

