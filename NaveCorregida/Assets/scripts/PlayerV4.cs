using UnityEngine;
using System.Collections;

/// <summary>
/// Nose movement to turn
/// </summary>
public class PlayerV4 : MonoBehaviour
{
    public float turnSpeed = 1;
    public float MaxPlaneRotationDegrees = 45;

    public float maxSpeed = 10;
    public float acceleration = 1;

    protected float currentSpeed = 0;

    protected Transform plane;

    protected FollowTarget[] followers;

    public float secondsOnEnd=2;
    public bool hasControl = true;

    // Use this for initialization
    void Start()
    {
        plane = transform.GetChild(0);

        // Esta operacion consume mucho, estamos buscando todos los objetos del tipo FollowTarget
        followers = FindObjectsOfType<FollowTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si tenemos el control de la nave
        if (hasControl)
        {
            currentSpeed += Time.deltaTime * acceleration;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
                //currentSpeed = currentSpeed + Time.deltaTime * acceleration > MaxSpeed ? MaxSpeed : currentSpeed + Time.deltaTime * acceleration > MaxSpeed;
            }


            var horiz = Input.GetAxis("Horizontal");
            transform.position = transform.position + transform.right * turnSpeed * horiz * Time.deltaTime;

          


            //Rotamos la nave en función del giro
            var r = plane.rotation.eulerAngles;
            r.z = Mathf.Lerp(-MaxPlaneRotationDegrees, MaxPlaneRotationDegrees, (-horiz + 1) / 2);

            plane.rotation = Quaternion.Lerp(plane.rotation, Quaternion.Euler(r), 0.1f);
        }


        //move forward
        transform.position = transform.position + transform.forward * Time.deltaTime * currentSpeed;


    }

    public void OnTriggerEnter(Collider other)
    {
        //Para evitar que esto pase varias veces seguidas
        if (hasControl)
        {
            if (other.tag == "TriggerEndLevel")
            {
                StartCoroutine(waitAndEnd());
            }
        }
    }

    protected IEnumerator waitAndEnd()
    {
        //Desactiva el script follow target haciendo que esos objetos se queden quietos
        for(int i = 0; i < followers.Length; i++)
        {
            followers[i].enabled = false;
        }
       
        hasControl = false;

        //Espera X segundos
        yield return new WaitForSeconds(secondsOnEnd);

        //avisar fin de nivel/cargar nuevo nivel.
    }
}


