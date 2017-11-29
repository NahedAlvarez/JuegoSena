using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerLeaderBoard : MonoBehaviour {
	public Text primerText;
	public Text segundoText;
	public Text tercerText;
	public int primerLugar=1;
	public int segundoLugar=2;
	public int tercerLugar=3;
	void Start () 
	{
		
	}
	

	void Update () 

	{
		primerText.text = "Score: "+primerLugar + PlayerPrefs.GetInt ("Player Score");

		segundoText.text = "Score: "+primerLugar + PlayerPrefs.GetInt ("PlayerScore");
	}
}
