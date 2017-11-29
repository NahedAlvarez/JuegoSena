using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayListExample : MonoBehaviour
{

    public GameObject[] AllGameObject;//Matriz unidimensional se le pretende asignar un tamaño con el array list

    void Start ()//se coloca en el start para que se ejecute nada mas comenzar
    {
        ArrayList alist = new ArrayList();//Se crea una array list donde se instancia los objetos de tipo array list para almacenar la informacion 
        object[] Allobject = GameObject.FindObjectsOfType(typeof(Object)) as Object[];//se buscan todos los objetos 
        foreach(Object o in Allobject)//o es el nombre que se lle asignan a los objetos en allObject que esta arriva guardando todos los objetos
        {
            GameObject go = o as GameObject;//se iguala la variable "go" a "o", se convierten en GameObjects 
            if (go != null)//si el valor es diferente de a nulo 
            {
                alist.Add(go);//lo añadira al array list que se llama "alist"
            }
        }

        AllGameObject = new GameObject[alist.Count];//El tamaño de la matriz sera igual a el tamaño de la Arraylist  
        alist.CopyTo(AllGameObject);//Se copian todos los elementos de game object
	}
}
