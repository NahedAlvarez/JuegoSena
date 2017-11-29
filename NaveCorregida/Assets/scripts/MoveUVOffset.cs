using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MoveUVOffset : MonoBehaviour {
    public Vector2 uVAnimationRate = Vector2.zero;
    protected Material mat;

    Vector2 uvOffset = Vector2.zero;
	// Use this for initialization
	void Start ()
    {
        mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update ()
    {
        uvOffset += uVAnimationRate * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", uvOffset);
	}
}
