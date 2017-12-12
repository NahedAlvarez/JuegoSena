using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text[] scoresText;
    float[] valorHighcores;
    string[] nombreJugadores;

    void Start()
    {
        valorHighcores = new float[scoresText.Length];
        nombreJugadores = new string[scoresText.Length];
        for (int i = 0; i < scoresText.Length;i++)
        {
            valorHighcores[i] = PlayerPrefs.GetFloat("ValoresScores"+i);
            nombreJugadores[i] = PlayerPrefs.GetString("Names" + i);
        }

        ModificandoLosTextosScoresLB();
    }

    public void CheckeandoLosScores(float scoreActual,string nameUser)
    {
        for (int i = 0; i < scoresText.Length; i++)
        {
           if(scoreActual > valorHighcores[i])
            {
                for (int j=valorHighcores.Length-1; j > i; j--)
                {
                    valorHighcores[j] = valorHighcores[j - 1];
                    nombreJugadores[j] = nombreJugadores[j - 1];
                }
                valorHighcores[i] = scoreActual;
                nombreJugadores[i] = nameUser;
                SaveData();
                ModificandoLosTextosScoresLB();

                break;
            }
        }
    }


    void SaveData()
    {
        for (int i = 0; i < scoresText.Length; i++)
        {
             PlayerPrefs.SetFloat("ValoresScores"+ i,valorHighcores[i]);
             PlayerPrefs.SetString("Names" + i, nombreJugadores[i]);
        }
    }


    void ModificandoLosTextosScoresLB()
    {
        for (int i = 0; i < scoresText.Length; i++)
        {
            scoresText[i].text = nombreJugadores[i]  + ": " + valorHighcores[i].ToString("0");

        }
    }
    public void BorrarPlayerprefs()
    {
        PlayerPrefs.DeleteAll();
    }

   
       
  

}




