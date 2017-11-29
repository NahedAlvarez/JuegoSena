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
        if (target == null)
        {
            Debug.Log("I don't have a target!");
        }

		offset = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, target.position.z - transform.position.z);

	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        transform.position = target.transform.position - offset;
	}
}
