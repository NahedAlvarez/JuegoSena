using UnityEngine;
using System.Collections;

/// <summary>
/// Nose movement to turn
/// </summary>
public class PlayerV3 : MonoBehaviour
{
    public float turnSpeed = 1;
    public float MaxPlaneRotationDegrees = 45;

    public float maxSpeed = 10;
    public float acceleration = 1;

    protected float currentSpeed = 0;

    protected Transform plane;
    // Use this for initialization
    void Start()
    {
        plane = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Ahora nuestra nave tiene una aceleracion
        currentSpeed += Time.deltaTime * acceleration;
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
            //currentSpeed = currentSpeed + Time.deltaTime * acceleration > MaxSpeed ? MaxSpeed : currentSpeed + Time.deltaTime * acceleration > MaxSpeed;
        }




        var horiz = Input.GetAxis("Horizontal");
        transform.position = transform.position + transform.right * turnSpeed * horiz * Time.deltaTime;

        transform.position = transform.position + transform.forward * Time.deltaTime * currentSpeed;


        //Rotamos la nave en función del giro
        var r = plane.rotation.eulerAngles;
        r.z = Mathf.Lerp(-MaxPlaneRotationDegrees, MaxPlaneRotationDegrees, (-horiz + 1) / 2);

        plane.rotation = Quaternion.Lerp(plane.rotation, Quaternion.Euler(r), 0.1f);
    }
}


