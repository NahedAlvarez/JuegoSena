using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    int c;
    public GameObject startUI;
    public GameObject endUI;

    public Text ScoreText;
    public Text ScoreGame;

    public GameObject CanvasScore;
  
    public InputField nicknameinputfield;
    public string nameUser;

    public int myLevel = 0;
    public Player player;

    public bool getControlOfPlayerAtStart = false;



 
    void Start()
    {

        c = 0;
        if (endUI != null)
        {
            endUI.SetActive(false);
        }

        if (getControlOfPlayerAtStart)
        {
            player.hasControl = false;
        }
      
        if (startUI != null)
        {
            startUI.SetActive(true);
            if (myLevel != 0)
            {
                loadLevel(0);
            }
            Player.Score = 0;
        }
        else
        {
            startGame();
        }
        


        player.manager = this;
    }

    void Update()
    {

        ScoreText.text = "Tu puntaje es " + Player.Score.ToString("0");
        if (nicknameinputfield != null)
        {
            nameUser = nicknameinputfield.text;
        }
        
    }





    public void ReStar()
    {

        loadLevel(0);

    }


   public void startGame()
    {
        if (startUI != null)
        {
            startUI.SetActive(false);

            CanvasScore.SetActive(true);

            myLevel = 0;
            
        }

        player.hasControl = true;
    }

   
    float Puntaje;
    public void endLevel()
    {
    

        if (endUI != null)
        {

            CanvasScore.SetActive(false);
            endUI.SetActive(true);
            endUI.gameObject.SetActive(true);
            ScoreGame.text =  Player.Score.ToString("0");
           

            Puntaje = Player.Score;
        }
        else
        {
            loadLevel(myLevel + 1);
        }

    }


    public void NombreJugador()
    {
        if (c==0)
        {

            GetComponent<Score>().CheckeandoLosScores(Puntaje, nameUser);
            c++;
        }
       
    }


    public void loadLevel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }



}