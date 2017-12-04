using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfMovimiento : MonoBehaviour {

    public GameObject ElQueseMueve;
    public GameObject dondeMueve;
    public GameObject salida;
    public float tiempoMovimiento;
   


    public void ActivarElMenu(string Activar)
    {
        switch (Activar)
        {
            case "si":

                transform.position = Vector3.MoveTowards(ElQueseMueve.transform.position, dondeMueve.transform.position, tiempoMovimiento * Time.deltaTime);

                break;
            case "no":
                transform.position = Vector3.MoveTowards(ElQueseMueve.transform.position, salida.transform.position, tiempoMovimiento * Time.deltaTime);

                break;
        }
    }
}
