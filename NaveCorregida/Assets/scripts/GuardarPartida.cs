using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPartida : MonoBehaviour {

    public int SaludJugador;
    public int nuevaSalud;
	public void GuardadoPartida ()
    {
        PlayerPrefs.SetInt("Sangre Jugador", SaludJugador);
        Debug.Log("Se guardo la sangre");
	}
	

	public void CargarPartida ()
    {
        nuevaSalud = PlayerPrefs.GetInt("Sangre Jugador");
        Debug.Log("Se cargo salud del jugador");
	}
}
