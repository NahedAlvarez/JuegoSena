using UnityEngine;
using System.Collections;

/// <summary>
/// Die/Respawn loop
/// </summary>
public class PlayerV5 : MonoBehaviour
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

    protected Vector3 initialPos;

    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;

        plane = transform.GetChild(0);

        followers = FindObjectsOfType<FollowTarget>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (hasControl)//Para evitar que esto pase varias veces seguidas
        {
            if (other.tag == "TriggerEndLevel")
            {
                StartCoroutine(waitAndEnd());
            }
            else if (other.tag == "Obstacles")
            {
                StartCoroutine(Respawn());
            }
        }
    }


    protected IEnumerator Respawn()
    {
        transform.position = initialPos;
        currentSpeed = 0;

        yield return null;
    }

    protected IEnumerator waitAndEnd()
    {
        for(int i = 0; i < followers.Length; i++)
        {
            followers[i].enabled = false;
        }

       
        hasControl = false;
        yield return new WaitForSeconds(secondsOnEnd);

        //avisar fin de nivel/cargar nuevo nivel.
    }
}


