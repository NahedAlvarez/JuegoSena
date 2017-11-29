using UnityEngine;
using System.Collections;


/// <summary>
/// Simple script for the camera to follow the player on runner game.
/// </summary>
public class FollowTarget : MonoBehaviour {
    public Transform target;
   
	// Use this for initialization
	
    private Vector3 offset;
    void Start () {
   

		offset = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, target.position.z - transform.position.z);

	}
	
	
	void LateUpdate () 
    {
        transform.position = target.transform.position - offset;
	}
}
