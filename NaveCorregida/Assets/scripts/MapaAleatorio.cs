using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaAleatorio : MonoBehaviour
{

    
    public Rigidbody primerTerreno;
    public Rigidbody segundoTerreno;
    public Rigidbody tercerTerreno;
    public Rigidbody cuartoTerreno;

    public int i=0;
    public Transform[] EspaciosTerreno;
    public int Point=0;


    void Start()
    {

        //Se hace un for para pasar por todos los terrenos 
        for (int i= 0; i < EspaciosTerreno.Length; i++)
           {


                int n = Random.Range(0, 4);

                
            //swith va conun numero entre 0 y 4  en todo momento se instancia uno de los suelos
                    switch (n)
                    {
                        case 0:
                            Rigidbody clone;
                            clone = Instantiate(primerTerreno, EspaciosTerreno[Point].transform.position, EspaciosTerreno[Point].transform.rotation) as Rigidbody;
                           
                            break;
                        case 1:
                            Rigidbody clone1;
                            clone1 = Instantiate(segundoTerreno, EspaciosTerreno[Point].transform.position, EspaciosTerreno[Point].transform.rotation) as Rigidbody;

                            break;
                        case 2:
                            Rigidbody clone2;
                            clone2 = Instantiate(tercerTerreno, EspaciosTerreno[Point].transform.position, EspaciosTerreno[Point].transform.rotation) as Rigidbody;
                      
                            break;
                        case 3:
                            Rigidbody clone3;
                            clone3 = Instantiate(cuartoTerreno, EspaciosTerreno[Point].transform.position, EspaciosTerreno[Point].transform.rotation) as Rigidbody;
                            break;
                        case 4:
                            Rigidbody clone4;
                            clone4 = Instantiate(cuartoTerreno, EspaciosTerreno[Point].transform.position, EspaciosTerreno[Point].transform.rotation) as Rigidbody;
                            break;
            }
            //Se aumenta gradualmente el punto para que valla aumentando de terreno y vaya pasando por todo
            Point++;
        }
    }

    /* private void NewMethod()q
     {
         switch (i)
         {
             case 0:

                 Rigidbody clone;
                 clone = Instantiate(primerTerreno, transform.position, transform.rotation) as Rigidbody;
                 break;
             case 1:
                 Rigidbody clone1;
                 clone1 = Instantiate(segundoTerreno, transform.position, transform.rotation) as Rigidbody;
                 break;
             case 2:
                 Rigidbody clone2;
                 clone2 = Instantiate(tercerTerreno, transform.position, transform.rotation) as Rigidbody;
                 break;
         }
    
    } */

}


