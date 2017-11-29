using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMultidimensional : MonoBehaviour {

    public int[,] DosDimensiones = new int[2, 3];/// dos columnas tre filas
    
    

	void Start ()
    {
        GameObject a = new GameObject("A");//De aqui se crean objetos con el nombre que se le  asigna
        GameObject b = new GameObject("B");
        GameObject c = new GameObject("C");
        GameObject d = new GameObject("D");
        GameObject e = new GameObject("E");
        GameObject f = new GameObject("F");//hasta aqui se termino de aignarles los nombres y crear objetos
        GameObject[,] dosDimensiones =
        new GameObject[2, 3] { { a, b, c }, { d, e, f } };// se asignan a una matriz  los game object (a,b,c,)  (d,e,f) en sus respectivas columnas 1 y 2
        inspectArray(dosDimensiones); //Se le asigna una asignacion al metodo que se esta llamando
    }
	

    void inspectArray(GameObject[,] gos)// gos es un nombre que se le da no es una funcion propia de unity tambien podria ser remplazada por patata
    {
        int columns = gos.GetLength(0);//GetLength(0) hace referencia al tamaño de las columnas
        Debug.Log("Columnas" + columns);//Se imprimen los datos de las mascotas
        int filas = gos.GetLength(1);//GetLength(0) hace referencia al tamaño de las Filas 
        Debug.Log("filas" + filas);
        for (int c=0; c<columns; c++)//se accede a las columnas atravez de un para 
        {
            for(int f=0; f < filas; f++)//se accede a cada fila de cada columna a travez de un para 
            {
                Debug.Log(gos[c, f].name);
            }
        }
    }



}

		