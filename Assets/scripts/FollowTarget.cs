using UnityEngine;
using System.Collections;



public class FollowTarget : MonoBehaviour
{
    //Se utiliza una variable de tipo tranform que contiene la ubicaciond el player 
    public Transform target;
   
	
	
    private Vector3 offset;
    void Start () {
   
        //se le obtiene una distancia a la que siempre va estar 
		offset = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, target.position.z - transform.position.z);

	}
	
	
	void LateUpdate () 
    {
        //Se le pide que siempre este a esta distancia 
        transform.position = target.transform.position - offset;
	}
}
