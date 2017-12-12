using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaAleatorio : MonoBehaviour
{

    
    public Rigidbody primerTerreno;
    public Rigidbody segundoTerreno;
    public Rigidbody tercerTerreno;
    public Rigidbody cuartoTerreno;
    public GameObject Moneda;
    int numeroMonedas;

    public int i=0;
    public Transform[] EspaciosTerreno;
    public int Point=0;
    int level;


    void Start()
    {
        //se hace un numero aleatorio para el numero para saver el numero de monedas que se deben instanciar 



             numeroMonedas = 55  ;
      

        //Se hace un for para pasar por todos los terrenos 
        for (int i= 0; i < EspaciosTerreno.Length; i++)
           {


               
                int n = Random.Range(0, 4);
                
            for (int j=0;j<numeroMonedas;j++)
            {
                 if(level == 0)
                 {
                    float xRange = Random.Range(-30, 22);
                    float yRange = -2;
                    float zRange = Random.Range(1, 860);
                    Instantiate(Moneda, new Vector3(xRange, yRange, zRange), Quaternion.identity);
                 }
                else if (level == 1)
                {
                    float xRange = Random.Range(-30, 22);
                    float yRange = -2;
                    float zRange = Random.Range(1, 1169);
                    Instantiate(Moneda, new Vector3(xRange, yRange, zRange), Quaternion.identity);
                }

               else if (level == 2)
                {
                    float xRange = Random.Range(-30, 22);
                    float yRange = -2;
                    float zRange = Random.Range(20, 1370.2f);
                    Instantiate(Moneda, new Vector3(xRange, yRange, zRange), Quaternion.identity);
                }
                else if (level == 3)
                {
                    float xRange = Random.Range(-30, 22);
                    float yRange = -2;
                    float zRange = Random.Range(6, 4643);
                    Instantiate(Moneda, new Vector3(xRange, yRange, zRange), Quaternion.identity);
                }

            }

       
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


    void Update()
    {
        level = Player.theLevel;
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


