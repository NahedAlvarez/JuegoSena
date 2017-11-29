using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {


    public Transform[] Point;
    public GameObject[] GameObjectArray;//se crea el array GameObjectArray definido sin tamaño 

    void Start()
    {
        ArrayList aList = new ArrayList();//se crea un array list sin tamaño para asignarselo
        GameObject[] gameObjects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));//Se crea el array gameobject de tipo GameObjects que busque todos los objetos de tipo GameObjects 
        foreach (GameObject go in gameObjects)//(go es cualquier mierda) para cada GameObject in gameObject 
        {
            if (go.name == "Point")//si se llama Sphere
            {

                aList.Add(go);//Agregelo al array list 

            }
        }

        GameObjectArray = aList.ToArray(typeof(GameObject)) as GameObject[];//El tamaño del object array se lo da la lista y es de tipo GameObject
    }



    void Update()
    {
        sortObjects(GameObjectArray, out GameObjectArray);//llamada al metodo SortObject que tiene como argumento GameObjectArray  
        for (int i = 0; i < GameObjectArray.Length; i++)//para cada uno de las esferas 
        {
            Vector3 PositionA = GameObjectArray[i].transform.position;//se toma la posicion de los objetos no los objetos 
            Debug.Log(PositionA);
            Debug.DrawRay(PositionA, new Vector3(0, i * 2f, 0), Color.red);
        }

    }


    
    void sortObjects(GameObject[] objects, out GameObject[] sortedObjects)
    {
        for (int i = 0; i < objects.Length - 1; i++)
        {
            Debug.Log("I del sort object " + i);
            Vector3 PositionA = objects[i].transform.position;//PosicionA esta tomando la posicion de un GameObject A
            Debug.Log("Position A" + PositionA);
            Vector3 PositionB = objects[i + 1].transform.position;//PosicionB  esta tomando la posicion de un GameObject B
            Debug.Log("Position B" + PositionB);
            Vector3 VectorToA = PositionA - transform.position;//Esta restando la posicion del GameObject A y la posicion del Objeto que tiene el scrip
            Debug.Log("VectorToA" + VectorToA);
            Vector3 VectorToB = PositionB - transform.position;//Esta restando la posicion del Game Object B  y la posicion del Objeto que contiene el scrip
            Debug.Log("VectorToB" + VectorToB);
            float DistanceToA = VectorToA.magnitude;//La distancia de la posicion A se guia por la magnitud que contiene ((x^2 + y^2 + z^2))
            Debug.Log("DistanceToA" + DistanceToA);
            float DistanceToB = VectorToB.magnitude;//La distancia de la posicion B se guia por la magnitud que contiene ((x^2 + y^2 + z^2))
            Debug.Log("DistanceToB" + DistanceToB);
            if (DistanceToA > DistanceToB)//La distancia A > Distancia B 
            {
                GameObject temp = objects[i];
                Debug.Log(temp);
                objects[i] = objects[i + 1];//Game Object i agregele i+1 y a i+1 = temp; 
                Debug.Log(objects);//Efect Burble se aplica lo siguiente 5,6,5 si tiene 
                objects[i + 1] = temp;//se busca que el organizar las esferas dependiendo de que sea mayor 
                Debug.Log(objects);
            }
        }

        sortedObjects = objects;//se le asigna un valor de retornno al sortedObject.
        Debug.Log(sortedObjects);
    }
}




