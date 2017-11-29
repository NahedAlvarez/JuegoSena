using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFija : MonoBehaviour {

    public float positionz;
    public float positionx;
    public float positiony;
    public Transform position;

    void Start ()
    {
        positionz = transform.position.z;
        positiony = transform.position.y;
        positionx = transform.position.x;

    }
	
	
	void Update ()
    {
        transform.position = new Vector3(positionx,positiony,positionz);
    }
}
