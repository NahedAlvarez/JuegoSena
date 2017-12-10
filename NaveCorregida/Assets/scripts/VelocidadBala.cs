using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadBala : MonoBehaviour
{

    public float velocidad = 100;
    public float x;
    public float y;
    public float z;




    void Update()
    {
        transform.Translate(new Vector3(x, y, z) * velocidad * Time.deltaTime, Space.World);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Obstacles"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }

    }
}
