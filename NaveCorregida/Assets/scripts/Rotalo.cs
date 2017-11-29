using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotalo : MonoBehaviour
{
    public float Z;
    public float X;
    public float Y;

    void Update()
    {
        transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime);
    }

 
}